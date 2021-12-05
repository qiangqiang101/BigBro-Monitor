<?php
/*======================================================================
| modsCMS - Build your own game mods website!
| ======================================================================
| This is a paid software, do not redistribute, support the developers.
| See licenses for more information about the use of the software.
\======================================================================*/

// core functions
include_once "core.php";

// check if is a valid ajax request
if(!empty($_SERVER['HTTP_X_REQUESTED_WITH']) && strtolower($_SERVER['HTTP_X_REQUESTED_WITH']) == 'xmlhttprequest')
{
	// ajax identification number
	$aid = filter($_POST["aid"]);
	
	switch($aid)
	{
		// user login
		case 1:
		$jsn["OK"] = false;
		
		// check if user is already logged
		if(!ONLINE)
		{
			// variables
			$username = filter($_POST["username"]);
			$password = filter($_POST["pass"]);
			
			// check empty files
			if(empty($username) || empty($password))
			{
				$jsn["msg"] = "There are empty fields.";
			}
			else
			{
				// try to login user
				$user = new user();
				$jsn = $user->login($username, $password);
			}
		}
		else
		{
			$jsn["msg"] = "You're already logged in. Refresh the page!";
		}
		break;
		
		// create a new account
		case 2:
		if(!ONLINE)
		{
			// variables
			$username = filter($_POST["username"]);
			$email    = filter($_POST["email"]);
			$pass1    = filter($_POST["pass1"]);
			$pass2    = filter($_POST["pass2"]);
			
			// check empty fields
			if(empty($username) || empty($email) || empty($pass1) || empty($pass2))
			{
				$jsn["msg"] = "There are empty fields.";
			}
			// check if email is valid
			elseif(!preg_match('/@.+\./', $email))
			{
				$jsn["msg"] = "Insert a valid email.";
			}
			// check if password is valid
			elseif(strlen($pass1) < 6 || strlen($pass1) > 20)
			{
				$jsn["msg"] = "Your password must have at least 6 characters and maximum 20.";
			}
			// check if passwords match
			elseif($pass1 != $pass2)
			{
				$jsn["msg"] = "The passwords don't match!";
			}
			// check if username has spaces
			elseif(preg_match('/\s/',$username))
			{
				$jsn["msg"] = "Username must not have spaces!";
			}
			// check if username is valid
			elseif(!preg_match('/^[a-z\d_]{3,20}$/i', $username))
			{
				$jsn["msg"] = "Username must contain only alphanumeric values, with a minimum of 3 characters and a maximum of 20 characters.";
			}
			else
			{
				// try to create account
				$user = new user();
				$jsn = $user->register($username, $email, $pass1);
			}
		}
		else
		{
			$jsn["msg"] = "You can't create a new account while being online.";
		}
		break;
		
		// update account settings
		case 3:
		if(ONLINE)
		{
			// variables
			$location = filter($_POST["location"]);
			$website  = filter($_POST["website"]);
			$about_me = filter($_POST["about_me"]);
			
			// update data
			$user = new user();
			$jsn = $user->update_account($location, $website, $about_me);
		}
		else
		{
			// must be online message
			$jsn["msg"] = "You must be online to update account informations.";
		}
		break;
		
		// change account password
		case 4:
		if(ONLINE)
		{
			$jsn["pass"] = "";
			
			// variables
			$cpass_key = filter($_POST["cpass"]);
			$current_pass = filter($_POST["pass0"]);
			$pass1 = filter($_POST["pass1"]);
			$pass2 = filter($_POST["pass2"]);
			
			// check empty fields
			if(empty($cpass_key))
			{
				$jsn["msg"] = "Could not read [CPASS KEY], please, refresh the page.";
			}
			elseif(empty($current_pass) || empty($pass1) || empty($pass2))
			{
				$jsn["msg"] = "There are empty fields.";
			}
			// check current password
			elseif(md5($current_pass) != $cpass_key)
			{
				$jsn["msg"] = "Wrong current password, try again.";
			}
			// check if new password is valid
			elseif(strlen($pass1) < 6 || strlen($pass1) > 20)
			{
				$jsn["msg"] = "Your new password must have at least 6 characters and maximum 20.";
			}
			// check if new passwords match
			elseif($pass1 != $pass2)
			{
				$jsn["msg"] = "The passwords don't match!";
			}
			else
			{
				// try to change password in database
				$user = new user();
				$jsn = $user->change_password($pass1);
			}
		}
		else
		{
			// must be online message
			$jsn["msg"] = "You must be online to change the account password.";
		}
		break;
		
		// update profile picture
		case 5:
		$jsn["OK"] = false;
		
		if(ONLINE)
		{
			// variables
			$img = $_POST["image"];
			
			// upload class
			include_once "inc/class.upload.php";
			
			// upload image to server
			$up = new upload("avatar");
			$image_id = $up->save_image($img);
			
			if($image_id != null)
			{
				$user = new user();
				$jsn = $user->update_picture($image_id);
			}
			else
			{
				$jsn["msg"] = "Error during image upload, try again with other image.";
			}
		}
		else
		{
			// must be online message
			$jsn["msg"] = "You must be online to update the profile picture.";
		}
		break;
		
		// upload mod screeshot
		case 6:
		$jsn["OK"] = false;
		
		if(ONLINE)
		{
			// variables
			$img = $_POST["image"];
			
			// upload class
			include_once "inc/class.upload.php";
			
			// upload image to server
			$up = new upload("image");
			$image_id = $up->save_image($img);
			
			if($image_id != null)
			{
				$jsn["OK"] = true;
				$jsn["img_id"] = $image_id;
				$jsn["img_url"] = SITE_URL.$up->dir.$image_id.'_thumb.jpg';
			}
			else
			{
				$jsn["msg"] = "Error during image upload, try again with other image.";
			}
		}
		else
		{
			// must be online message
			$jsn["msg"] = "You must be online to add a screenshot, please, refresh the page.";
		}
		break;
		
		// upload file
		case 7:
		$jsn["OK"] = false;
		
		if(ONLINE)
		{
			// variables
			$file = $_FILES["file"];
			
			// check file errors
			if(0 < $file['error'])
			{				
				// treat upload errors
				switch($file["error"])
				{
					case 1: $msg = 'The file exceeds the PHP <b>upload_max_filesize</b> directive (in php.ini).<br>Current server file max size allowed is: <b>'.ini_get('upload_max_filesize').'B</b>.'; break;
					case 2: $msg = 'The uploaded file exceeds the MAX_FILE_SIZE directive that was specified in the HTML form.'; break;
					case 3: $msg = 'The uploaded file was only partially uploaded.'; break;
					case 4: $msg = 'No file was uploaded.'; break;
					case 5: $msg = ''; break;
					case 6: $msg = 'Missing a temporary folder.'; break; // PHP 5.0.3
					case 7: $msg = 'Failed to write file to disk.'; break; // PHP 5.1.0
					case 8: $msg = 'A PHP extension stopped the file upload'; break; // PHP 5.2.0
				}
				
				$jsn["msg"] = $msg;
			}
			else
			{				
				// upload class
				include_once "inc/class.upload.php";
				
				// upload file to server
				$up = new upload("file");
				
				if($up->save_file($file) != false)
				{
					// success, return json parameters
					$jsn["OK"] = true;
					$jsn["file_id"] = $up->name;
				}
				else
				{
					// file upload error message
					$jsn["msg"] = "Error during file upload, please, contact administration.";
				}
			}
		}
		else
		{
			// must be online message
			$jsn["msg"] = "You must be online to upload a file, please, refresh the page.";
		}
		break;
		
		// upload mod
		case 8:
		$jsn["OK"] = false;
		
		if(ONLINE)
		{
			// variables
			$mods->name     = filter($_POST["filename"]);
			$mods->version  = filter($_POST["version"]);
			$mods->author   = filter($_POST["author"]);
			$mods->category = filter($_POST["category"]);
			$mods->description = $mods->filter_desc($_POST["description"]);
			$mods->file_id  = filter($_POST["file_id"]);
			$seo = filter($_POST["seo"]);
			
			if($mods->category == 0)
			{
				$jsn["msg"] = "Select a valid mod category.";
			}
			else if(empty($mods->name) || empty($mods->author) || empty($mods->description))
			{
				$jsn["msg"] = "There are empty fields.";
			}
			elseif(empty($seo))
			{
				$jsn["msg"] = "SEO ID was not found, please, refresh the page and try again.";
			}
			elseif(empty($mods->file_id))
			{
				$jsn["msg"] = "Uploaded File ID was not found, please, refresh the page and try again. Or contact administration if problem persists.";
			}
			elseif(count($_POST["imgPic"]) == 0)
			{
				$jsn["msg"] = "You should upload at least one screenshot.";
			}
			else
			{
				// check seo
				$mods->seo = $mods->check_seo($seo);
				
				// format screenshots
				$mods->format_images($_POST["imgPic"]);
				
				// try to upload a new mod
				$jsn = $mods->upload();
			}
		}
		else
		{
			// must be online message
			$jsn["msg"] = "You must be online to upload a mod, please, refresh the page.";
		}
		break;
		
		// add a comment
		case 9:
		$jsn["OK"] = false;
		
		if(ONLINE)
		{
			// variables
			$mod_id = filter($_POST["mod_id"]);
			$comment = filter($_POST["comment"]);
			
			// check mod id
			if(empty($mod_id) || !is_numeric($mod_id))
			{
				$jsn["msg"] = "Invalid MOD ID parameter, could not comment. Refresh the page!";
			}
			// check comment
			elseif(empty($comment))
			{
				$jsn["msg"] = "Your comment can't be empty.";
			}
			else
			{
				// try to add the comment
				$jsn = $mods->add_comment($mod_id, $comment);
			}
		}
		else
		{
			// must be online message
			$jsn["msg"] = "You must be online to comment. <a href=\"login\">Login now!</a>";
		}
		break;
		
		// load more comments based on last comment id 
		case 10:
		$jsn["OK"] = false;
		
		// variables
		$mod_id = filter($_POST["mod_id"]);
		$last_id = filter($_POST["last_id"]);
		
		// check if mod id is valid
		if(!empty($mod_id))
		{
			// check last comment id
			if(empty($last_id) || !is_numeric($last_id))
			{
				$jsn["msg"] = "Invalid Page ID. Refresh the page!";
			}
			else
			{
				// load comments html
				$jsn["OK"] = true;
				$jsn["html"] = $mods->load_comments($mod_id, $last_id);
			}
		}
		else
		{
			// error message
			$jsn["msg"] = "Invalid Mod ID. Refresh the page!";
		}
		break;
		
		// remove a comment
		case 11:
		$jsn["OK"] = false;
		
		if(ONLINE)
		{
			// variables
			$comment_id = filter($_POST["cid"]);
			
			// try to remove comment
			$jsn = $mods->remove_comment($comment_id);
		}
		else
		{
			// must be online message
			$jsn["msg"] = "You must be online to remove a comment.";
		}
		break;
		
		// edit a mod
		case 12:
		$jsn["OK"] = false;
		
		if(ONLINE)
		{
			// variables
			$mods->id = filter($_POST["mid"]);
			$mods->name = filter($_POST["filename"]);
			$mods->version = filter($_POST["version"]);
			$mods->author = filter($_POST["author"]);
			$mods->category = filter($_POST["category"]);
			$mods->description = $mods->filter_desc($_POST["description"]);
			$mods->file_id  = filter($_POST["file_id"]);
			
			if(empty($mods->id))
			{
				$jsn["msg"] = "Invalid Mod ID, refresh the page.";
			}
			elseif($mods->category == 0)
			{
				$jsn["msg"] = "Select a valid mod category.";
			}
			elseif(empty($mods->name) || empty($mods->author) || empty($mods->description))
			{
				$jsn["msg"] = "There are empty fields.";
			}
			elseif(empty($mods->file_id))
			{
				$jsn["msg"] = "Uploaded File ID was not found, please, refresh the page and try again. Or contact administration if problem persists.";
			}
			elseif(count($_POST["imgPic"]) == 0)
			{
				$jsn["msg"] = "You should upload at least one screenshot.";
			}
			else
			{
				// format images
				$mods->format_images($_POST["imgPic"]);
				
				// try to update the mod
				$jsn = $mods->update();
			}
		}
		else
		{
			$jsn["msg"] = "You must be online to edit a mod. <a href=\"login\">Login here &raquo;</a>";
		}
		break;
		
		// save admin notes
		case 13:
		if(RANK == 2)
		{
			// try to update admin notes
			if(file_put_contents(ADM_NOTES, filter($_POST["notes"])) !== false)
			{
				$jsn["msg"] = "Admin notes saved!";
			}
			else
			{
				// error message
				$jsn["msg"] = "Error: Could not update admin notes, check if path is correct in <b>inc.vars.php</b> file!";
			}
		}
		else
		{
			// must be online/admin message
			$jsn["msg"] = "You must be online/be admin to update notes.";
		}
		break;
		
		// save admin website settings
		case 14:
		if(RANK == 2)
		{
			global $db;
			
			// variables
			$site_name = filter($_POST["site_name"]);
			$site_domain = filter($_POST["site_domain"]);
			$meta_desc = filter($_POST["description"]);
			$meta_keys = filter($_POST["keywords"]);
			$site_footer = $db->con->real_escape_string($_POST["site_footer"]);
			$mpp = filter($_POST["mpp"]);
			$cpl = filter($_POST["cpl"]);
			$noi = filter($_POST["noi"]);
			$max_upload = filter($_POST["max_upload"]);
			$max_image = filter($_POST["max_image"]);
			
			// check if there are empty fields
			if(empty($site_name) || empty($site_domain) || empty($site_footer) || empty($mpp))
			{
				$jsn["msg"] = "There are empty fields.";
			}
			// check if 'mods per page' is an integer
			elseif(!is_numeric($mpp))
			{
				$jsn["msg"] = "The mods per page should be a number.";
			}
			// check if 'comments per loading' is an integer
			elseif(!is_numeric($cpl))
			{
				$jsn["msg"] = "The comments per loading should be a number.";
			}
			// check if 'number of images' is an integer
			elseif(!is_numeric($noi))
			{
				$jsn["msg"] = "The gallery max number of images should be a number.";
			}
			// check the max number of images allowed for galleries 
			elseif($noi == 0)
			{
				$jsn["msg"] = "The gallery max number of images can't be zero.";
			}
			// check max upload file size for mods
			elseif(!is_numeric($max_upload) || $max_upload == 0)
			{
				$jsn["msg"] = "The upload max file size should be a number and other than 0.";
			}
			// check max upload file size for images 
			elseif(!is_numeric($max_image) || $max_image == 0)
			{
				$jsn["msg"] = "The images max file size should be a number and other than 0.";
			}
			else
			{
				// update website settings values on database
				if(dbquery('UPDATE config SET site_name = "'.$site_name.'", site_url = "'.$site_domain.'", site_desc = "'.$meta_desc.'", site_keys = "'.$meta_keys.'", site_footer = "'.$site_footer.'", mpp = '.$mpp.', cpl = '.$cpl.', noi = '.$noi.', mfs_upload = '.$max_upload.', mfs_image = '.$max_image.''))
				{
					$jsn["msg"] = "Website Settings saved!";
				}
				else
				{
					// db error message
					$jsn["msg"] = "Database error, could not update website settings.";
				}
			}
		}
		else
		{
			// must be online/admin message
			$jsn["msg"] = "You must be online/de admin to update website settings.";
		}
		break;
		
		// save website ads
		case 15:
		
		// user must be admin
		if(RANK == 2)
		{
			global $db;
			
			// variables
			$ads_status = filter($_POST["enable_ads"]);
			$adsense = $db->con->real_escape_string($_POST["adsense_code"]);
			$adcode_1 = $db->con->real_escape_string($_POST["adcode1"]);
			$adcode_2 = $db->con->real_escape_string($_POST["adcode2"]);
			$adcode_3 = $db->con->real_escape_string($_POST["adcode3"]);
			
			// check if 'enabled ads' is valid
			if($ads_status == 0 || $ads_status == 1)
			{
				// try to update website ads settings 
				if(dbquery('UPDATE config SET ads_status = '.$ads_status.', adsense_code = "'.$adsense.'", ads_1 = "'.$adcode_1.'", ads_2 = "'.$adcode_2.'", ads_3 = "'.$adcode_3.'"'))
				{
					$jsn["msg"] = "Advertisements saved!";
				}
			}
			else
			{
				// invalid ads value
				$jsn["msg"] = "Invalid 'Ads Enable' value, refresh the page.";
			}
		}
		else
		{
			// must be online/admin message
			$jsn["msg"] = "You must be online/be admin to update website ads.";
		}
		break;
		
		// admin mod edit
		case 16:
		
		$jsn["OK"] = false;
		
		// user must be admin
		if(RANK == 2)
		{
			// item variables
			$mods->id = filter($_POST["mid"]);
			$mods->name = filter($_POST["filename"]);
			$mods->version = filter($_POST["version"]);
			$mods->author = filter($_POST["author"]);
			$mods->category = filter($_POST["category"]);
			$mods->description = $mods->filter_desc($_POST["description"]);
			$mods->file_id = filter($_POST["file_id"]);
			
			// item settings variables
			$mods->status = filter($_POST["status"]);
			$mods->reason = filter($_POST["reason"]);
			$mods->seo = filter($_POST["seo"]);
			$mods->downloads = filter($_POST["downs"]);
			
			// check if mod id is valid
			if(empty($mods->id))
			{
				$jsn["msg"] = "Invalid Mod ID, refresh the page.";
			}
			// check if category is empty
			elseif($mods->category == 0)
			{
				$jsn["msg"] = "Select a valid mod category.";
			}
			// check if important fields are empty
			elseif(empty($mods->name) || empty($mods->author) || empty($mods->description))
			{
				$jsn["msg"] = "There are empty fields.";
			}
			// check if file id is valid
			elseif(empty($mods->file_id))
			{
				$jsn["msg"] = "Uploaded File ID was not found, please, refresh the page and try again. Or contact administration if problem persists.";
			}
			// check if seo is valid
			elseif(empty($mods->seo))
			{
				$jsn["msg"] = "SEO url can't be empty.";
			}
			// total downloads can't be empty
			elseif($mods->downloads == "")
			{
				$jsn["msg"] = "Insert a valid downloads number.";
			}
			// check if mod status is valid
			elseif($mods->status < 0 || $mods->status > 3)
			{
				$jsn["msg"] = "Invalid status ID, please, refresh the page.";
			}
			elseif($mods->status == 2 && empty($mods->reason))
			{
				$jsn["msg"] = "You must enter a reason why the mod was rejected.";
			}
			// should upload at least one screenshot
			elseif(count($_POST["imgPic"]) == 0)
			{
				$jsn["msg"] = "You should upload at least one screenshot.";
			}
			else
			{		
				// format images
				$mods->format_images($_POST["imgPic"]);
				
				// update mods informations
				$jsn = $mods->adm_update_mod();
			}
		}
		else
		{
			// must be online/admin message
			$jsn["msg"] = "You must be online/be admin to update a mod.";
		}
		break;
		
		// adm edit user
		case 17:		
		
		// user must be admin
		if(RANK == 2)
		{
			// variables
			$uid = filter($_POST["uid"]);
			$rank = filter($_POST["rank"]);
			$location = filter($_POST["location"]);
			$about_me = filter($_POST["about"]);
			$website = filter($_POST["website"]);
			$avatar = filter($_POST["avatar"]);
			
			if(empty($avatar)){ $avatar = "default"; }
			
			// check if admin is trying to change it's rank to normal user
			if($uid == UID && $rank == 1)
			{
				$jsn["msg"] = 'As an administrator, you can\'t change your admin rank to normal user.';
			}
			// check if admin is trying to ban itself
			elseif($uid == UID && $rank == 0)
			{
				$jsn["msg"] = 'As an administrator, you can\'t ban yourself.';
			}
			// try to update user's informations
			else if(dbquery('UPDATE users SET rank = '.$rank.', location = "'.$location.'", about = "'.$about_me.'", website = "'.$website.'", avatar = "'.$avatar.'" WHERE uid = '.$uid))
			{
				$jsn["msg"] = 'User successfully updated!';
			}
			else
			{
				// database error message
				$jsn["msg"] = "Database error! Could not update user data.<br>Refresh the page!";
			}
		}
		else
		{
			// must be online/admin message
			$jsn["msg"] = "You must be online/be admin to update an user account.";
		}
		break;
		
		// delete a mod from database
		case 18:
		$jns["OK"] = false;
		
		// user must be admin
		if(RANK == 2)
		{
			// variables
			$mid = filter($_POST["mid"]);
			
			// check agreement (this avoid user to delete by mistake)
			if(!isset($_POST["verify"]))
			{
				$jsn["msg"] = 'You must agree to delete first (checkbox).';
			}
			else
			{
				// try to delete the mod from database
				if(dbquery('DELETE FROM mods WHERE mid = '.$mid))
				{
					// try to delete mod comments
					dbquery('DELETE FROM comments WHERE mod_id = '.$mid);
					$jsn["OK"] = true;
				}
				else
				{
					// database error message
					$jsn["msg"] = 'Database error, could not remove the mod, or it\'s already removed!';
				}
			}
		}
		else
		{
			// must be online/admin message
			$jsn["msg"] = "You must be online/be admin to delete a mod.";
		}
		break;
	}
	
	// send response as json format
	die(json_encode($jsn));
}
else
{
	// it's not an ajax request, redirect to homepage
	header("Location: ".SITE_URL); exit;
}

?>