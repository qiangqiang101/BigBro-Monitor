<?php
/*======================================================================
| modsCMS - Build your own game mods website!
| ======================================================================
| This is a paid software, do not redistribute, support the developers.
| See licenses for more information about the use of the software.
\======================================================================*/

// core functions
include_once "core.php";

// no session check needed

if(isset($_GET["user"]))
{
	// username
	$username = filter($_GET["user"]);
	
	// pagination id
	if(isset($_GET["pid"]) && is_numeric($_GET["pid"]) && $_GET["pid"] != 0){ $mods->page_id = $_GET["pid"]; } else { $mods->page_id = 1; }
	
	// load user data by username
	$user = new user();
	$user->uploads_check($username);
	
	// check if user exists/enabled
	if($user->exists && $user->rank != 0)
	{
		// page settings
		$mods->page_query = 'user_id = '.$user->id.' AND status = 1';
		$mods->pagination_url = 'uploads_by/'.$username.'/';
		
		// set page parameters
		$tpl->set_param("user", $username);
		$tpl->set_param("user_uploads", $mods->load_list("_profile"), true);
		$tpl->set_param("pagination", $mods->pagn());
	}
	else
	{
		// not found
		header("Location: ".SITE_URL."404?user_not_found"); exit;
	}
}

// page
$tpl->set_param("sel_cat", -1);
$tpl->set_param("page_title", "Uploads by ".$username);
$tpl->load("head");
$tpl->load("uploads_by");
$tpl->load("footer");
$tpl->output();
?>