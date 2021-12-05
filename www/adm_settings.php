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

// page params
$tpl->set_param("mpp", $mods->mpp);
$tpl->set_param("cpl", $mods->cpl);
$tpl->set_param("noi", $config["noi"]);
$tpl->set_param("mfs_upload", $config["mfs_upload"]);
$tpl->set_param("mfs_image", $config["mfs_image"]);
$tpl->set_param("mfs_server", ini_get('upload_max_filesize'));

// page
$tpl->set_param("sel_cat", 4);
$tpl->set_param("page_title", "Settings");
$tpl->load("adm_head");
$tpl->load("adm_settings");
$tpl->load("adm_footer");
$tpl->output();
?>