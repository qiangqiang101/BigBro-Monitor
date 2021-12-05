<?php
/*======================================================================
| modsCMS - Build your own game mods website!
| ======================================================================
| This is a paid software, do not redistribute, support the developers.
| See licenses for more information about the use of the software.
\======================================================================*/

// core functions
include_once "core.php";

// session check
seg(3);

// check if user id value is valid
if(isset($_GET["uid"]) && is_numeric($_GET["uid"]))
{
	// user id
	$uid = filter($_GET["uid"]);
	
	// load user by id
	$user = new user();
	$user->load($uid, "uid");
	
	// check if user exists
	if($user->exists)
	{
		// user params
		$tpl->set_param("user_id", $uid);
		$tpl->set_param("rank", $user->rank);
		$tpl->set_param("user_username", $user->username);
		$tpl->set_param("email", $user->email);
		$tpl->set_param("location", $user->location);
		$tpl->set_param("about", $user->about_me);
		$tpl->set_param("website", $user->website);
		$tpl->set_param("avatar", $user->avatar);
		$tpl->set_param("ip_address", $user->ip);
		$tpl->set_param("join_date", date("m/d/Y", $user->unix));
	}
	else
	{
		header("Location: ".SITE_URL."404?userNotFound"); exit;
	}
}
else
{
	header("Location: ".SITE_URL."404?invalidUserID"); exit;
}

// page
$tpl->set_param("sel_cat", 2);
$tpl->set_param("page_title", "Edit User");
$tpl->load("adm_head");
$tpl->load("adm_edit_user");
$tpl->load("adm_footer");
$tpl->output();
?>