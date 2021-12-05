<?php
/*======================================================================
| modsCMS - Build your own game mods website!
| ======================================================================
| This is a paid software, do not redistribute, support the developers.
| See licenses for more information about the use of the software.
\======================================================================*/

class user{
	
	// account settings values
	// rank (0 -> banned | 1 -> normal user | 2 -> admin )
	
	// account
	public $id = 0;
	public $username = "";
	public $password = "";
	public $email = "";
	public $rank = 0;
	public $avatar = "";
	public $unix = "";
	public $ip;
	public $exists = false;
	
	// information
	public $about_me = "";
	public $location = "";
	public $website = "";
	
	function __construct()
	{
	}
	
	// load user account data
	function load($input, $type)
	{
		// search user in database
		$query = dbquery('SELECT * FROM users WHERE '.$type.' = "'.$input.'"');
		
		// user found
		if($query->num_rows == 1)
		{
			// get user data
			$data = $query->fetch_assoc();
			
			// set user class variables
			$this->id = $data["uid"];
			$this->username = $data["username"];
			$this->password = $data["pass"];
			$this->email = $data["email"];
			$this->rank = $data["rank"];
			$this->avatar = $data["avatar"];
			$this->about_me = $data["about"];
			$this->location = $data["location"];
			$this->website = $data["website"];
			$this->unix = $data["unixtime"];
			$this->ip = $data["ip"];
			$this->exists = true;
		}
	}
	
	// try to login an user
	function login($username, $pass)
	{
		$jsn["OK"] = false;
		
		// search account in database
		$query = dbquery('SELECT uid, username, pass, rank, avatar FROM users WHERE username = "'.$username.'" AND pass = "'.md5($pass).'"');
		
		// check if account exists
		if($query->num_rows == 0)
		{
			// error message [not found]
			$jsn["msg"] = "Wrong username or password. Try again!";
		}
		else
		{
			// get account information
			$data = $query->fetch_assoc();
			
			// check if user is banned
			if($data["rank"] == 0)
			{
				$jsn["msg"] = "This account is banned, you can't login!";
			}
			else
			{
				// start user session
				$_SESSION["uid"]      = $data["uid"];
				$_SESSION["username"] = $data["username"];
				$_SESSION["rank"]     = $data["rank"];
				$_SESSION["avatar"]   = $data["avatar"];
				
				// success message
				$jsn["OK"] = true;
			}
		}
		return $jsn;
	}
	
	// create a new account
	function register($username, $email, $pass)
	{
		$jsn["OK"] = false;
		
		// check if username exists
		if($this->check_if_exists($username, "username") == 1)
		{
			$jsn["msg"] = "Username registered! Choose another!";
		}
		// check if email exists
		elseif($this->check_if_exists($email, "email") == 1)
		{
			$jsn["msg"] = "Email registered! Choose another!";
		}
		else
		{
			// try to register a new user on database
			if(dbquery('INSERT INTO users (username, pass, email, rank, location, about, website, avatar, ip, unixtime) VALUES ("'.$username.'", "'.md5($pass).'", "'.$email.'", 1, "", "", "", "default", "'.$_SERVER["REMOTE_ADDR"].'", "'.time().'")'))
			{
				// success
				$_SESSION["created"] = true;
				$jsn["OK"] = true;
			}
			else
			{
				// database error message
				$jsn["msg"] = "Database error, could not create account, contact administration!";
			}
		}
		return $jsn;
	}
	
	// update account data
	function update_account($location, $website, $about_me)
	{
		// try to update database information
		if(dbquery('UPDATE users SET location = "'.$location.'", website = "'.$website.'", about = "'.$about_me.'" WHERE uid = '.UID))
		{
			// success
			$jsn["msg"] = "Account changes saved!";
		}
		else
		{
			// database error message
			$jsn["msg"] = "Database error, could not update account information.";
		}
		
		return $jsn;
	}
	
	// update user password
	function change_password($new_pass)
	{
		$jsn["pass"] = "";
		$pass = md5($new_pass);
		
		// update password on database
		if(dbquery('UPDATE users SET pass = "'.$pass.'" WHERE uid = '.UID))
		{
			// success
			$jsn["msg"] = "Password successfully changed!";
			$jsn["pass"] = $pass;
		}
		else
		{
			// database error message
			$jsn["msg"] = "Database error, could not change the password.";
		}
		
		return $jsn;
	}
	
	// update profile picture
	function update_picture($img_id)
	{
		$jsn["OK"] = false;
		
		// update user avatar image on database
		if(dbquery('UPDATE users SET avatar = "'.$img_id.'" WHERE uid = '.UID))
		{
			// update session values
			$_SESSION["avatar"] = $img_id;
			$jsn["OK"] = true;
			$jsn["url"] = SITE_URL.'uploads/avatars/'.$img_id.'_thumb.jpg';
		}
		else
		{
			// database error message
			$jsn["msg"] = "Database error, could not update profile picture.";
		}
		
		return $jsn;
	}
	
	// check if username/email exists in database
	function check_if_exists($input, $type)
	{
		$query = dbquery('SELECT * FROM users WHERE '.$type.' = "'.$input.'"');
		return $query->num_rows;
	}
	
	// check user uploads
	function uploads_check($username)
	{
		// get user information from database
		$query = dbquery('SELECT uid, rank FROM users WHERE username = "'.$username.'"');
		
		// check if user exists
		if($query->num_rows == 1)
		{
			// user data
			$data = $query->fetch_assoc();
			
			// set user data
			$this->id     = $data["uid"];
			$this->rank   = $data["rank"];
			$this->exists = true;
		}
	}	
}

?>