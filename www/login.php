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
seg(1);

// page
$tpl->set_param("sel_cat", -1);
$tpl->set_param("page_title", "Login");
$tpl->load("head");
$tpl->load("login");
$tpl->load("footer");
$tpl->output();
?>