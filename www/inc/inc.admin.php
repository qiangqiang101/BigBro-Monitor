<?php
/*======================================================================
| modsCMS - Build your own game mods website!
| ======================================================================
| This is a paid software, do not redistribute, support the developers.
| See licenses for more information about the use of the software.
\======================================================================*/

// html list of users
function list_users($page_id)
{
	// pagination start limit
	$init = ($page_id - 1) * 12;
	
	// get users from database
	$query = dbquery('SELECT * FROM users ORDER BY uid DESC LIMIT '.$init.', 12');
	
	// check if there are users registered
	if($query->num_rows == 0)
	{
		$arr["pgn"] = "";
		
		if($page_id == 1)
		{
			$arr["html"] = 'No users registered at the moment.';
		}
		else
		{
			$arr["html"] = 'No users found in this page. <a onclick="history.go(-1);">&laquo; Go Back</a>';
		}
	}
	else
	{
		global $tpl;
		
		$tpl_html = $tpl->load_file("users_list");
		$tpl_txt = array("%user_id%", "%username%", "%user_email%", "%user_pic%");
		
		$h = '<div class="list-users cf">';
		
		while($data = $query->fetch_assoc())
		{
			$vars = array($data["uid"], $data["username"], $data["email"], $data["avatar"]);
			$h .= str_replace($tpl_txt, $vars, $tpl_html);
		}
		
		$h .= '</div>';
		
		$arr["html"] = $h;
		$arr["pgn"] = users_pagn($page_id);
	}
	
	return $arr;
}

// get the total of registered users
function total_users()
{
	$query = dbquery('SELECT COUNT(*) FROM users');
	$rows = $query->fetch_row();
	return $rows[0];
}

// users pagination
function users_pagn($page_id)
{
	$total = ceil(total_users() / 12);
	$ldp = 0;
	
	if($total >= 1)
	{
		$total = intval($total);
		
		$output = '<div class="more">';
		
		$current_page = (false == isset($page_id)) ? 1 : $page_id;
		
		for($page = 1; $page < $total + 1; $page++)
		{
			$lower = $current_page - 3;
			$upper = $current_page + 3;
			
			$special = ($page == $current_page) ? ' class="sel"' : '';
			
			if(($page > $lower && $page < $upper) || $page < 2 || $page > ($total-1))
			{
				if($ldp + 1 != $page) $output .= '... ';
				$output .= '<a'.$special.' href="adm_users?pid='.$page.'">'.$page.'</a>';
				$ldp = $page;
			}
		}
		
		$output .= '</div>';
		return $output;
	}
}

?>