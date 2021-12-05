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
seg(2);

// get curret user session information
$user = new user();
$user->load(UID, "uid");

// set page params
$tpl->set_param("email", $user->email);
$tpl->set_param("location", $user->location);
$tpl->set_param("website", $user->website);
$tpl->set_param("about_me", $user->about_me);
$tpl->set_param("cpass", $user->password);
$tpl->set_param("avatar", $user->avatar);
$tpl->set_param("mfs_image", $config["mfs_image"]);

// page
$tpl->set_param("sel_cat", -1);
$tpl->set_param("page_title", "Account Settings");
$tpl->load("head");
$tpl->load("settings");
$tpl->load("footer");
$tpl->output();
?>