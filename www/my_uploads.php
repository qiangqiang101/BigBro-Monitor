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

// pagination id
if(isset($_GET["pid"]) && is_numeric($_GET["pid"]) && $_GET["pid"] != 0){ $mods->page_id = $_GET["pid"]; } else { $mods->page_id = 1; }

// mod page settings
$mods->page_query = 'user_id = '.UID;
$mods->pagination_url = "my_uploads?pid=";

// load my uploads
$tpl->set_param("my_uploads", $mods->load_my_uploads(), true);
$tpl->set_param("pagination", $mods->pagn());

// page
$tpl->set_param("sel_cat", -1);
$tpl->set_param("page_title", "My Uploads");
$tpl->load("head");
$tpl->load("my_uploads");
$tpl->load("footer");
$tpl->output();
?>