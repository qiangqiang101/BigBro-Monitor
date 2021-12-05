<?php
/*======================================================================
| modsCMS - Build your own game mods website!
| ======================================================================
| This is a paid software, do not redistribute, support the developers.
| See licenses for more information about the use of the software.
\======================================================================*/

class template{
	
	// class variables
	public $output;
	public $params = array();
	
	function __construct($config)
	{		
		// set default website values
		$this->set_param("site_name",   $config["site_name"]);
		$this->set_param("site_url",    $config["site_url"]);
		$this->set_param("site_desc",   $config["site_desc"]);
		$this->set_param("site_keys",   $config["site_keys"]);
		$this->set_param("site_footer", $config["site_footer"]);
		
		// username stuff
		$this->set_param("username", USERNAME);
		
		// if admin, show admin panel button
		$adm_h = (RANK == 2)?'<a class="btn" href="adm">Admin Panel</a>':'';
		$this->set_param("adm_btn", $adm_h);
		
		// top menus stuff
		$menu = (ONLINE)?"on":"off";
		$this->set_param("top_menus", $this->load_file("menus_".$menu), true);
		$this->set_param("avatar_pic", AVATAR);
		
		// advertisements
		if($config["ads_status"])
		{
			$levelads = $config["adsense_code"];
			$ads1 = $config["ads_1"];
			$ads2 = $config["ads_2"];
			$ads3 = '<div class="wbox adsbox">'.$config["ads_3"].'</div>';
		}
		else
		{
			$levelads = "";
			$ads1 = "";
			$ads2 = "";
			$ads3 = "";
		}
		
		// ads codes
		$this->set_param("adsense", $levelads);
		$this->set_param("ads_1", $ads1);
		$this->set_param("ads_2", $ads2);
		$this->set_param("ads_3", $ads3);
	}
	
	// load a tpl file
	function load($file)
	{
		$this->output .= $this->load_file($file);
	}
	
	// load a tpl file
	function load_file($file)
	{
		// tpl file directory name
		$tpl = TPL_PATH."/".$file.".tpl";
		
		// check if tpl file exists in directory
		if(file_exists($tpl))
		{
			// get html of tpl
			ob_start();
			include($tpl);
			$data = ob_get_contents();
			ob_end_clean();
			return $data;
		}
		else
		{
			// erro message - tpl file is missing
			$this->error("Could not find the file: <b>".$file.".tpl</b> in <b>".TPL_PATH."</b> path.");
		}
	}
	
	// replace params of a single loaded file (doesn't add to output)
	function load_rep($file)
	{
		return $this->replace_params($this->load_file($file));
	}
	
	// set a new key/val parameter
	function set_param($key, $value, $s = false)
	{
		if($s)
		{
			// create a new parameter and replace an existing parameter inside new parameter's value
			$this->params[$key] = $this->replace_params($value);
		}
		else
		{
			// crate a new parameter
			$this->params[$key] = $value;
		}
	}
	
	// unset a parameter
	function unset_param($key)
	{
		unset($this->params[$key]);
	}
	
	// replace parameters in html
	function replace_params($html)
	{
		foreach($this->params as $param => $value)
		{
			$html = str_ireplace('%' . $param . '%', $value, $html);
		}
		return $html;
	}
	
	// add a new html line to the output
	function write($line)
	{
		$this->output .= $line;
	}
	
	// show final html
	function output()
	{
		echo $this->replace_params($this->output).PHP_EOL;
	}
	
	// html error message
	function error($message)
	{
		die('<h2>Error</h2>'.$message);
	}
}

?>