<?php
/*======================================================================
| modsCMS - Build your own game mods website!
| ======================================================================
| This is a paid software, do not redistribute, support the developers.
| See licenses for more information about the use of the software.
\======================================================================*/

error_reporting(E_ALL);

// function to filter inputs
function filter($txt)
{
	$txt = trim($txt);
	$txt = stripslashes($txt);
	$txt = strip_tags($txt);
	return $txt;
}

// function to return html error message
function error($msg){ return '<div class="error">'.$msg.'</div>'; }

// json settings
$json["OK"] = false;
$aid = filter($_POST["aid"]);

// treatment of functions based on 'AJAX ID'
switch($aid)
{
	// database settings
	case 2:
	
	   // form values
	   $db_host = filter($_POST["host"]);
	   $db_name = filter($_POST["name"]);
	   $db_user = filter($_POST["username"]);
	   $db_pass = filter($_POST["pass"]);
	   
	   // check if there are empty fields
	   if(empty($db_host) || empty($db_name) || empty($db_user) || empty($db_pass))
	   {
		   $json["msg"] = error("Please, fill all the blank fields.");
	   }
	   else
	   {
		   // try to connect to database
		   $con = @mysqli_connect($db_host, $db_user , $db_pass, $db_name);
		   
		   // connection failed
		   if (!$con)
		   {
			   // returns an error message
			   $json["msg"] = error("Failed to connect to MySQL, please, enter valid values.");
		   }
		   else
		   {
			   // connection is 'ok'
			   mysqli_set_charset($con, "utf8");
			   
			   // inc.config.php file text
			   $content = '<?php $db_host = "'.$db_host.'"; $db_user = "'.$db_user.'"; $db_pass = "'.$db_pass.'"; $db_name = "'.$db_name.'"; ?>';
			   
			   // try to write configuration file in engine folder
			   $fp = fopen("../inc/inc.config.php","wb");
			   if(fwrite($fp, $content))
			   {
				   fclose($fp);
				   
				   // get content from database SQL file
				   $sql = file_get_contents('db.sql');
				   
				   // try to import SQL content to database
				   if(mysqli_multi_query($con, $sql))
				   {
					   $json["OK"] = true;
				   }
				   else
				   {
					   // error during db-config.php creation
					   $json["msg"] = error("Configuration file (inc.config.php) was created, but we could not import the 'db.sql' to the mysql database.<br>Please, do it manually, the .SQL file is in the install folder. After this <a href=\"index.php?step=3\">click here</a> to continue the installation.");
				   }
			   }
			   else
			   {
				   $json["msg"] = error("Could not create the inc.config.php file in 'inc' folder, please, contact product support.");
			   }
		   }
	   }
	break;
	
	// website settings
	case 3:
	   // include db configuration file
	   require_once "../inc/inc.config.php";
	   
	   // try to connect to database
	   $con = @mysqli_connect($db_host, $db_user, $db_pass, $db_name);
	   
	   // success connected
	   if($con)
	   {
		   // form values
		   $site_name = filter($_POST["name"]);
		   $site_url = filter($_POST["url"]);
		   $description = filter($_POST["desc"]);
		   $keywords = filter($_POST["keywords"]);
		   
		   // check if there are empty fields
		   if(empty($site_name) || empty($site_url) || empty($description) || empty($keywords))
		   {
			   $json["msg"] = error("Please, fill all the blank fields.");
		   }
		   // check if website domain/url is valid and ends with slash '/'
		   elseif(substr($site_url, -1) != "/")
		   {
			   $json["msg"] = error("The website URL must end with a slash ( / ).");
		   }
		   else
		   {
			   mysqli_set_charset($con, "utf8");
			   
			   // update website settings values on database
			   if(mysqli_query($con, 'UPDATE config SET site_name = "'.$site_name.'", site_url = "'.$site_url.'", site_desc = "'.$description.'", site_keys = "'.$keywords.'", site_footer = "&copy; '.$site_name.' - All Rights Reserved"'))
			   {
				   $json["OK"] = true;
			   }
			   else
			   {
				   // database error message
				   $json["msg"] = error('Database error during the process. Try again or contact support.');
			   }
		   }		   
	   }
	   else
	   {
		   $json["msg"] = error("Could not connect to MYSQL database. <a href=\"index.php?step=2\">Click here</a> to set database settings.");
	   }
	   
	break;
	
	// create administrator account
	case 4:
	   // include db configuration file
	   require_once "../inc/inc.config.php";
	   
	   // try to connect to database
	   $con = @mysqli_connect($db_host, $db_user, $db_pass, $db_name);
	   
	   // success connected
	   if($con)
	   {
		   // 'check if user exists' function (based on username and email)
		   function checkuser($field, $value, $con)
		   {
			   $query = mysqli_query($con, 'SELECT uid FROM users WHERE '.$field.' = "'.$value.'"');
			   return mysqli_num_rows($query);
		   }
		   
		   // form values
		   $username = filter($_POST["username"]);
		   $email = filter($_POST["email"]);
		   $pass1 = filter($_POST["pass1"]);
		   $pass2 = filter($_POST["pass2"]);
		   
		   // check if there are empty fields
		   if(empty($username) || empty($email) || empty($pass1) || empty($pass2))
		   {
			   $json["msg"] = error('Please, fill all the blank fields.');
		   }
		   elseif($pass1 != $pass2)
		   {
			   $json["msg"] = error('Passwords don\'t match. Try again!');
		   }
		   else
		   {
			   // those usernames are blocked to register
			   $blacklist = array("js", "css", "inc", "images", "setup", "profile", "user");
			   
			   // check if username is blocked
			   if(in_array(strtolower($username), $blacklist))
			   {
				   $json["msg"] = error('Username blocked, choose another.');
			   }
			   // check if username has at least 3 characters
			   else if(strlen($username) < 3)
			   {
				   $json["msg"] = error('Username must have at least 3 characters long.');
			   }
			   // check if username is in valid format
			   elseif(!preg_match('/^[a-za-zA-Z\d_]{3,15}$/i', $username))
			   {
				   $json["msg"] = error('Username must contain only alphanumeric characters, without spaces.');
			   }
			   // check if username is already registered
			   elseif(checkuser("username", $username, $con) == 1)
			   {
				   $json["msg"] = error('Username already in use, choose another.');
			   }
			   // check if email is already registered
			   elseif(checkuser("email", $email, $con) == 1)
			   {
				   $json["msg"] = error('Email already registered, choose another.');
			   }
			   else
			   {
				   // password encryption
				   $password = md5($pass1);
				   
				   // create administrator user account
				   if(mysqli_query($con, 'INSERT INTO users (username, pass, email, rank, location, about, website, avatar, ip, unixtime) VALUES ("'.$username.'", "'.$password.'", "'.$email.'", 2, "", "", "", "default", "'.$_SERVER["REMOTE_ADDR"].'", "'.time().'")'))
				   {
					   $json["OK"] = true;
				   }
				   else
				   {
					   // database error message
					   $json["msg"] = error('Database error during the process. Try again or contact support.');
				   }
			   }
		   }
	   }
	   else
	   {
		   $json["msg"] = error("Could not connect to MYSQL database. <a href=\"index.php?step=2\">Click here</a> to set database settings.");
	   }
	   
	break;
}

// return a json format message
die(json_encode($json));
?>