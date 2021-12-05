<?php
/*======================================================================
| modsCMS - Build your own game mods website!
| ======================================================================
| This is a paid software, do not redistribute, support the developers.
| See licenses for more information about the use of the software.
\======================================================================*/

// core functions
include_once "core.php";

// security check
seg(3);

$term = "";
$pagn = "";
$results = '<font color="#666">You must enter a valid name!</font>';

// search can't be empty
if(isset($_GET["term"]) || !empty($_GET["term"]))
{
	// search term
	$term = filter($_GET["term"]);
	
	// check if search name/value is empty	
	if(empty($term))
	{
		$results = '<div class="msg mt_e">Your search can\'t be empty.</div>';
	}
	else
	{
		// pagination id
		if(isset($_GET["pid"]) && is_numeric($_GET["pid"]) && $_GET["pid"] != 0){ $mods->page_id = $_GET["pid"]; } else { $mods->page_id = 1; }
		
		// page settings
		$mods->page_query = 'name LIKE "%'.$term.'%" ORDER BY mid DESC';
		$mods->page_no_results = "No mods were found to this search. Try again with other terms!";
		$mods->pagination_url = 'adm_search?term='.$term.'&pid=';		
		
		// load mods
		$results = $mods->adm_uploads();
		$pagn = $mods->pagn();
		
	}
}

// page params
$tpl->set_param("term", $term);
$tpl->set_param("results", $results, true);
$tpl->set_param("pagination", $pagn);

// page
$tpl->set_param("sel_cat", 1);
$tpl->set_param("page_title", "Results for: ".$term);
$tpl->load("adm_head");
$tpl->load("adm_search");
$tpl->load("adm_footer");
$tpl->output();
?>