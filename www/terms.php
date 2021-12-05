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

// page
$tpl->set_param("sel_cat", -1);
$tpl->set_param("page_title", "Terms of Use");
$tpl->load("head");
$tpl->load("terms");
$tpl->load("footer");
$tpl->output();
?>