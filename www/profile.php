<?php
/*======================================================================
| modsCMS - Build your own game mods website!
| ======================================================================
| This is a paid software, do not redistribute, support the developers.
| See licenses for more information about the use of the software.
\======================================================================*/

// core functions
include_once "core.php";

// default page variables
$page_title = "User Not Found";
$page_tpl = "profile_404";
	
// check username
if(isset($_GET["username"]))
{
	// filter username string
	$username = filter($_GET["username"]);
	
	// load user data by username
	$user = new user();
	$user->load($username, "username");
	
	// check if user exists and it's not banned
	if($user->exists && $user->rank != 0)
	{
		// page variables
		$page_title = "Mods by ".$username;
		$page_tpl = "profile";
		
		// admin tag if user rank = 2
		$user_tag = ($user->rank == 2)?'<div class="admin_tag">Admin</div>':'';
		
		// user params
		$tpl->set_param("p_username", $username);
		$tpl->set_param("location", $user->location);
		$tpl->set_param("about_me", str_replace("\n", "<br />", $user->about_me));
		$tpl->set_param("avatar", $user->avatar);
		
		$website = ($user->website != null)?'<a href="'.$user->website.'" target="_blank">'.$user->website.'</a>':'';
		$tpl->set_param("website", $website);
		
		// mods params
		$mods->page_id = 1;
		$mods->page_query = 'user_id = '.$user->id.' AND status = 1';
		$tpl->set_param("user_uploads", $mods->load_list("_profile"), true);
		$tpl->set_param("user_tag", $user_tag);
	}
}

// page
$tpl->set_param("sel_cat", -1);
$tpl->set_param("page_title", $page_title);
$tpl->load("head");
$tpl->load($page_tpl);
$tpl->load("footer");
$tpl->output();
?>