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

include_once "inc/inc.admin.php";

// pagination page id
if(isset($_GET["pid"]) && is_numeric($_GET["pid"]) && $_GET["pid"] != 0){ $page_id = $_GET["pid"]; } else { $page_id = 1; }

// list all registered users (banned, active and admin members)
$users = list_users($page_id);

// page params
$tpl->set_param("users_list", $users["html"]);
$tpl->set_param("pagination", $users["pgn"]);

// page
$tpl->set_param("sel_cat", 2);
$tpl->set_param("page_title", "Users");
$tpl->load("adm_head");
$tpl->load("adm_users");
$tpl->load("adm_footer");
$tpl->output();
?>