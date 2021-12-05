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
$tpl->set_param("ads_status", $config["ads_status"]);
$tpl->set_param("adsense_code", $config["adsense_code"]);
$tpl->set_param("adm_ads_1", $config["ads_1"]);
$tpl->set_param("adm_ads_2", $config["ads_2"]);
$tpl->set_param("adm_ads_3", $config["ads_3"]);

// page
$tpl->set_param("sel_cat", 3);
$tpl->set_param("page_title", "Advertisements");
$tpl->load("adm_head");
$tpl->load("adm_ads");
$tpl->load("adm_footer");
$tpl->output();
?>