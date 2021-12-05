<?php
/*======================================================================
| modsCMS - Build your own game mods website!
| ======================================================================
| This is a paid software, do not redistribute, support the developers.
| See licenses for more information about the use of the software.
\======================================================================*/

class upload{
	
	public $name = "";
	public $dir  = "";
	public $thumb_width = 0;
	public $type = "";
	
	function __construct($up_type)
	{
		// generate an unique name for the file/image based on current user ID
		$this->name = uniqid(UID.'-');
		$this->type = $up_type;
		
		// load definitions based on upload file type 
		switch($up_type)
		{
			case "file": $this->dir = "uploads/files/"; break;
			
			case "image":
			$this->dir = "uploads/imgs/";
			$this->thumb_width = 500;
			break;
			
			case "avatar":
			$this->dir = "uploads/avatars/";
			$this->thumb_width = 75;
			break;		
		}
	}
	
	/*
	    returns image ID name ( eg: 00_xxx ) or null ( error )
	*/
	function save_image($img)
	{
		// read the b64 image string
		$img = str_replace('data:image/jpeg;base64,', '', $img);
		$img = str_replace(' ', '+', $img);
		$data = base64_decode($img);
		
		// final destination of image
		if(file_put_contents($this->dir.$this->name.'.jpg', $data))
		{
			// save action in log
			$this->save_log($this->name.'.jpg');
			
			// generate thumbnail
			$this->image_thumb($data);
			
			return $this->name;
		}
		else
		{
			return null;
		}
		
	}
	
	/*
	    thumb images will be loaded using: image ID name + _thumb ( eg: 00_xxx_thumb.jpg )
	*/
	function image_thumb($src)
	{
		// read the source image
		$source = imagecreatefromstring($src);
		$width = imagesx($source);
		$height = imagesy($source);
		
		// find the "desired height" of this thumbnail, relative to the desired width
		$desired_height = floor($height * ($this->thumb_width / $width));
		
		// create virtual image
		$virtual_image = imagecreatetruecolor($this->thumb_width, $desired_height);
		
		// copy source image at a resized size
		imagecopyresampled($virtual_image, $source, 0, 0, 0, 0, $this->thumb_width, $desired_height, $width, $height);
		
		// create the physical thumbnail image to its destination
		imagejpeg($virtual_image, $this->dir.$this->name.'_thumb.jpg', 100);
	}
	
	/*
	   save file to server after errors verification
	*/
	function save_file($file)
	{				
		$this->name = $this->name.'.'.pathinfo($file["name"], PATHINFO_EXTENSION);
		
		// save action in log
		$this->save_log($this->name);
		
		// return if upload was a success
		return move_uploaded_file($file["tmp_name"], $this->dir.$this->name);
	}
	
	// save in log when some file is uploaded
	function save_log($save_name)
	{
		// check if is to save
		if(LOG_STATUS)
		{
			// open or creates a new log file according to the date
			$file = fopen(LOG_PATH.date("Y-m-d").".txt","a+");
			
			// write a new line with action
			fwrite($file, "[".date("h:i:s")."] UserID: ".UID." | Filename: ".$save_name." | Type: ".$this->type.PHP_EOL);
			fclose($file);
		}
	}
}

?>