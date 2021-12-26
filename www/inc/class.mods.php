<?php
/*======================================================================
| modsCMS - Build your own game mods website!
| ======================================================================
| This is a paid software, do not redistribute, support the developers.
| See licenses for more information about the use of the software.
\======================================================================*/

class mods{
	
	// status = (0 => pending | 1 => approved | 2 => rejected)
	
	// mod item variables
	public $id;
	public $name;
	public $version;
	public $seo;
	public $category;
	public $description;
	public $author;
	public $file_id;
	public $front_image;
	public $images;
	public $status = 0;
	public $last_edited;
	public $downloads;
	public $comments;
	public $unix;
	public $exists = false;
	public $reason = "";
	
	// mod author variables
	public $user_id;
	public $username;
	public $user_avatar;
	
	// loading mods settings
	public $mpp; // mods per page
	public $lmn; // loaded mods number
	public $cpl; // comments per loading
	
	// mod page settings
	public $page_id;
	public $page_query;
	public $page_no_results = "";
	public $pagination_url;
	
	// mod categories list 
	public $cats_list = array(
	5 => "3.5 Inch", 
	1 => "5 Inch", 
	2 => "7 Inch", 
	3 => "8.8 Inch", 
	4 => "Misc"
	);	
	
	function __construct($config)
	{
		$this->mpp = $config["mpp"];
		$this->cpl = $config["cpl"];
	}
	
	// load mod informations
	function load($input, $type)
	{
		// get information from database
		$query = dbquery('SELECT a.*, b.username, b.avatar FROM mods a, users b WHERE a.'.$type.' = "'.$input.'" AND a.user_id = b.uid');
		
		// check if mod exists
		if($query->num_rows == 1)
		{
			// load mod information
			$data = $query->fetch_assoc();
			
			// set values
			$this->id   = $data["mid"];
			$this->name = $data["name"];
			$this->version  = $data["version"];
			$this->seo      = $data["seo"];
			$this->category = $data["catid"];
			$this->description = $data["description"];
			$this->author   = $data["author"];
			$this->file_id  = $data["file_id"];
			$this->front_image = $data["front_image"];
			$this->images = $data["images"];		
			$this->last_edited = (empty($data["last_edited"]))?'':date("Y-m-d", $data["last_edited"]);
			$this->reason = $data["rej_reason"];
			$this->downloads = $data["downs"];
			$this->comments = $data["total_comments"];
			$this->user_id  = $data["user_id"];
			$this->username = $data["username"];
			$this->user_avatar = $data["avatar"];
			$this->status = $data["status"];
			$this->unix = date("Y-m-d", $data["unixtime"]);
			$this->exists = true;
		}
	}
	
	// load mod comments
	function load_comments($mod_id, $last_id)
	{
		$html = "";
		
		// check last comment id to load from
		if($last_id == 0){ $qs = 'ORDER BY a.cid DESC LIMIT '.$this->cpl; } else { $qs = ' AND a.cid < '.$last_id.' ORDER BY a.cid DESC LIMIT '.$this->cpl; }
		
		// load comments from database
		$query = dbquery('(SELECT a.cid, a.by_uid, a.comment, a.unixtime, b.username, b.avatar, b.rank, c.user_id FROM comments a, users b, mods c WHERE a.mod_id = '.$mod_id.' AND c.mid = '.$mod_id.' AND b.uid = a.by_uid AND a.visible = 1 '.$qs.') ORDER BY cid ASC');
		
		// check if there are comments
		if($query->num_rows != 0)
		{
			global $tpl;
			$tpl_html = $tpl->load_file("comment");
			$tpl_txt = array("%cid%", "%user%", "%avatar%", "%comment%", "%tag%", "%infos%");
			
			// list comments
			while($data = $query->fetch_assoc())
			{
				$unix = $data["unixtime"];
				$time = $this->time_elapsed("@$unix");
				$tag = $this->user_tag($data["rank"], $data["by_uid"], $data["user_id"]);
				
				// check if user is admin or comment author
				if($data["by_uid"] == UID || RANK == 2){ $infos = '<a onclick="remove_comment('.$data["cid"].')">remove</a> &middot; '.$time; } else { $infos = $time; }
				
				// check links on comment
				$comment = preg_replace('%(http[s]?://)(\S+)%', '<a href="\1\2" target="_blank">\2</a>', $data["comment"]);
				
				// check usernames (@some_username) on comment
				$comment = preg_replace('/(^|\s)@([a-z0-9_]+)/i', '$1<a href="user/$2">@$2</a>', $comment);
				
				$vars = array($data["cid"], $data["username"], $data["avatar"], str_replace("\n", "<br />", $comment), $tag, $infos);
				
				$html .= str_replace($tpl_txt, $vars, $tpl_html);
			}
			
			return $tpl->replace_params($html);
		}
				
		return $html;
	}
	
	// load current user session uploads
	function load_my_uploads()
	{
		$init = ($this->page_id - 1) * $this->mpp;
		
		$query = dbquery('SELECT * FROM mods WHERE '.$this->page_query.' ORDER BY mid DESC LIMIT '.$init.', '.$this->mpp);
		
		$this->lmn = $query->num_rows;
		
		if($query->num_rows == 0)
		{
			if($this->page_id == 1)
			{
				return '<font color="#666">You don\'t have uploaded themes.<br><br><a href="upload" class="btn up_btn">Upload my first Theme &raquo;</a></font>';
			}
			else
			{
				return 'There are no themes to see at this page ('.$this->page_id.').<br><br><a href="my_uploads" class="btn">&laquo; Go back</a>';
			}
		}
		else
		{
			global $tpl;
			
			// tpl settings
			$tpl_html = $tpl->load_file("my_item");
			$tpl_txt = array("%name%", "%downs%", "%author%", "%front_image%", "%status%", "%mod_url%", "%total_com%");
			
			$h = '<div class="list-item cf">';
			
			while($data = $query->fetch_assoc())
			{
				$url = '';
				$status = $data["status"];
				
				// mod is under admin review
				if($status == 0 || $status == 3)
				{
					$url = ' onclick="wait();"';
				}
				// mod approved
				elseif($status == 1)
				{
					$url = ' href="view/'.$data["seo"].'"';
				}
				// mod rejected
				elseif($status == 2)
				{
					$url = ' href="edit/'.$data["seo"].'"';
				}
				
				$vars = array($data["name"], $data["downs"], $data["author"], $data["front_image"], $status, $url, $data["total_comments"]);
				
				$h .= str_replace($tpl_txt, $vars, $tpl_html);
			}
			
			$h .= '</div>';
			
			return $h;
		}
	}
	
	// load search/category/profile mods
	function load_list($nm = "")
	{
		global $tpl;
		
		$init = ($this->page_id - 1) * $this->mpp;
		
		// load mods from database
		$query = dbquery('SELECT * FROM mods WHERE '.$this->page_query.' ORDER BY mid DESC LIMIT '.$init.', '.$this->mpp);
		
		$this->lmn = $query->num_rows;
		
		// no mods were found
		if($query->num_rows == 0)
		{
			if($this->page_id == 1)
			{
				return $tpl->load_file("no_mods".$nm);
			}
			else
			{
				return 'There are no themes to see at this page ('.$this->page_id.').<br><br><a onclick="history.go(-1);" class="btn">&laquo; Go back</a>';
			}
		}
		else
		{
			// tpl settings
			$tpl_html = $tpl->load_file("mod_item");
			$tpl_txt = array("%name%", "%downs%", "%front_image%", "%author%", "%seo%", "%total_com%");
			
			$h = '<div class="list-item cf">';
			
			while($data = $query->fetch_assoc())
			{
				$vars = array($data["name"], $data["downs"], $data["front_image"], $data["author"], $data["seo"], $data["total_comments"]);
				
				$h .= str_replace($tpl_txt, $vars, $tpl_html);
			}
			
			$h .= '</div>';
			
			return $h;
		}
	}
	
	// add a new mod to database
	function upload()
	{
		$jsn["OK"] = false;
				
		// insert mod information
		if(dbquery('INSERT INTO mods (user_id, name, version, seo, catid, description, author, file_id, front_image, images, status, downs, total_comments, last_edited, rej_reason, unixtime) VALUES ("'.UID.'", "'.$this->name.'", "'.$this->version.'", "'.$this->seo.'", "'.$this->category.'", "'.$this->description.'", "'.$this->author.'", "'.$this->file_id.'", "'.$this->front_image.'", "'.$this->images.'", 0, 0, 0, "", "", "'.time().'")'))
		{
			$jsn["OK"] = true;
		}
		else
		{
			// database error message
			$jsn["msg"] = "Database error during mod upload, try again or contact administration.";
		}
		
		return $jsn;
	}
	
	// update a mod
	function update()
	{
		$jsn["OK"] = false;
		
		// check if mod exists and its from current user
		$query = dbquery('SELECT user_id, status FROM mods WHERE mid = '.$this->id.' AND user_id = '.UID);
		
		if($query->num_rows == 1)
		{
			$data = $query->fetch_assoc();
			
			// check if status is rejected
			if($data["status"] == 2 || $data["status"] == 3)
			{
				// if yes, change to 'resent' status
				$status = 3;
			}
			else
			{
				// status approved
				$status = 1;
			}
			
			// try to update mod informations on database
			if(dbquery('UPDATE mods SET name = "'.$this->name.'", version = "'.$this->version.'", catid = '.$this->category.', description = "'.$this->description.'", author = "'.$this->author.'", file_id = "'.$this->file_id.'", front_image = "'.$this->front_image.'", images = "'.$this->images.'", status = '.$status.', last_edited = "'.time().'" WHERE mid = '.$this->id))
			{
				$jsn["OK"] = true;
			}
			else
			{
				// database error message
				$jsn["msg"] = "Database error during mod edition, try again or contact administration.";	
			}
		}
		else
		{
			// invalid edition / mod is not from current user session
			$jsn["msg"] = "This is not your Mod ID. Refresh the page now!";
		}
		
		return $jsn;
	}
		
	// check if seo exists, if yes, create another
	function check_seo($seo)
	{
		// check mod database seo's
		$query = dbquery('SELECT mid FROM mods WHERE seo = "'.$seo.'"');
		
		// seo already exists
		if($query->num_rows != 0)
		{
			// create a new seo id
			$seo = $seo.'-'.UID.mt_rand(1,100);
		}
		
		return $seo;
	}
	
	// format front image and screenshot images
	function format_images($img_array, $bits = "")
	{
		// front page image
		$this->front_image = filter($img_array[0]);
		
		// screenshots, remove front image
		$screens = array_shift($img_array);
		
		// check if exists screenshots
		if(count($img_array) > 0)
		{
			// create screens array string
			foreach($img_array as $img_id){ $bits .= filter($img_id).";"; }
			$this->images = substr($bits, 0, -1);
		}
		else
		{
			// empty screenshots
			$this->images = "";
		}
	}
	
	// get total number of mods using page query (used for pagination)
	function get_total()
	{
		$query = dbquery('SELECT COUNT(*) FROM mods WHERE '.$this->page_query);
		$rows = $query->fetch_row();
		return $rows[0];
	}
	
	// pagination html
	function pagn()
	{
		if($this->lmn != 0)
		{
			$total = ceil($this->get_total() / $this->mpp);
			$ldp = 0;
			
			if($total >= 1)
			{
				$total = intval($total);
				
				$output = '<div class="more">';
				
				$current_page = (false == isset($this->page_id)) ? 1 : $this->page_id;
				
				for($page=1; $page < $total + 1; $page++)
				{
					$lower = $current_page - 3;
					$upper = $current_page + 3;
					
					$special = ($page == $current_page) ? ' class="sel"' : '';
					
					if(($page > $lower && $page < $upper) || $page < 2 || $page > ($total-1))
					{
						if($ldp + 1 != $page) $output .= '... ';
						$output .= '<a'.$special.' href="'.$this->pagination_url.$page.'">'.$page.'</a>';
						$ldp = $page;
					}
				}
				
				$output .= '</div>';
				return $output;	
			}
		}
		
		return '';
	}
	
	// filter mod description ( allow html tags )
	function filter_desc($txt)
	{
		global $db;
		$txt = trim($txt);
		$txt = stripslashes($txt);
		$txt = strip_tags($txt, "<b><a><ul><li><i><ol>");
		return $db->con->real_escape_string($txt);
	}
	
	// load mod screenshots for view page
	function load_screens()
	{
		if($this->images != "")
		{
			$bits = explode(";", $this->images);
			
			$html = '<div class="gallery cf"><center>';			
			
			// list screenshots
			foreach($bits as $img_id)
			{
				$html .= '<a onclick="oia(\'%site_url%uploads/imgs/'.$img_id.'.jpg\');"><div class="thumb" style="background-image:url(%site_url%uploads/imgs/'.$img_id.'_thumb.jpg);"></div></a>';
			}
			
			$html .= '</center></div>';
			
			return $html;
		}
		
		return "";
	}
	
	// load view gallery
	function edit_gallery($gallery = "")
	{
		$screen_bits = array();
		
		if($this->images != ""){ $screen_bits = explode(";", $this->images); }
		
		// add mod front image to the screenhosts list
		array_unshift($screen_bits, $this->front_image);
		
		// list each image in edition mode
		foreach($screen_bits as $image)
		{
			$gallery .= '<div class="uimg ui_'.$image.'"><div class="img_prev" style="background-image:url(%site_url%/uploads/imgs/'.$image.'_thumb.jpg);"></div><input type="hidden" name="imgPic[]" value="'.$image.'"><input type="button" value="Remove" class="remove_btn" onclick="rip(\''.$image.'\');"></div>';
		}
		
		return $gallery;
	}
	
	// add comment to a mod
	function add_comment($mod_id, $comment)
	{
		$jsn["OK"] = false;
		
		// get mod and current user session information from database
		$query = dbquery('SELECT a.mid, a.user_id, b.avatar, b.rank FROM mods a, users b WHERE a.mid = '.$mod_id.' AND b.uid = '.UID.' AND a.status = 1');
		
		if($query->num_rows == 1)
		{
			$data = $query->fetch_assoc();
						
			// is commenter mod author ?
			$tag = $this->user_tag(RANK, UID, $data["user_id"]);
					
			// insert comment in database
			if(dbquery('INSERT INTO comments (by_uid, mod_id, comment, visible, unixtime) VALUES ('.UID.', '.$mod_id.', "'.$comment.'", 1, "'.time().'")'))
			{
				global $db;
				
				// get user last comment id
				$last_id = $db->con->insert_id;
				
				// update the total number of comments of the mod
				if(dbquery('UPDATE mods SET total_comments = (total_comments + 1) WHERE mid = '.$mod_id))
				{
					global $tpl;
					
					// check links on comment
					$comment = preg_replace('%(http[s]?://)(\S+)%', '<a href="\1\2" target="_blank">\2</a>', $comment);
					
					// check usernames (@some_username) on comment
					$comment = preg_replace('/(^|\s)@([a-z0-9_]+)/i', '$1<a href="user/$2">@$2</a>', $comment);
					
					// set comment params
					$tpl->set_param("cid", $last_id);
					$tpl->set_param("user", USERNAME);
					$tpl->set_param("avatar", $data["avatar"]);
					$tpl->set_param("tag", $tag);
					$tpl->set_param("comment", $comment);
					$tpl->set_param("infos", '<a onclick="remove_comment('.$last_id.')">remove</a> &middot; just now');
					
					$jsn["OK"] = true;
					$jsn["htmlt"] = $tpl->load_rep("comment");
				}
				else
				{
					$jsn["msg"] = "Database error during total comments update.";
				}
			}
			else
			{
				$jsn["msg"] = "Database error during comment, try again or contact administration.";
			}
		}
		else
		{
			$jsn["msg"] = "Mod doesn't exist or was removed.<br>Please, refresh the page!";
		}
		
		return $jsn;
	}
	
	// load all mods by type
	function adm_uploads()
	{
		$init = ($this->page_id - 1) * $this->mpp;
		
		$query = dbquery('SELECT * FROM mods WHERE '.$this->page_query.' LIMIT '.$init.', '.$this->mpp);
		
		$this->lmn = $query->num_rows;
		
		if($query->num_rows == 0)
		{
			if($this->page_id == 1)
			{
				return '<font color="#666">'.$this->page_no_results.'</font>';
			}
			else
			{
				return 'There are no themes to see at this page ('.$this->page_id.').<br><br><a onclick="history.go(-1);" class="btn">&laquo; Go back</a>';
			}
		}
		else
		{
			global $tpl;
			
			$tpl_html = $tpl->load_file("my_item");
			$tpl_txt = array("%name%", "%downs%", "%author%", "%front_image%", "%status%", "%mod_url%", "%total_com%");
			
			$h = '<div class="list-item cf">';
			
			while($data = $query->fetch_assoc())
			{			
				$vars = array($data["name"], $data["downs"], $data["author"], $data["front_image"], $data["status"], ' href="adm_edit?mid='.$data["mid"].'"', $data["total_comments"]);
				
				$h .= str_replace($tpl_txt, $vars, $tpl_html);
			}
			
			$h .= '</div>';
			
			return $h;
		}
	}
	
	// remove a comment 
	function remove_comment($cid)
	{
		$jsn["OK"] = false;
		
		// check if comment exists
		$query = dbquery('SELECT * FROM comments WHERE cid = '.$cid);
		
		if($query->num_rows == 1)
		{
			// get the mod id value
			$data = $query->fetch_assoc();
			$mod_id = $data["mod_id"];
			
			if($data["by_uid"] == UID || RANK == 2)
			{
				// update visibility of the comment -> hide comment
				if(dbquery('UPDATE comments SET visible = 0 WHERE cid = '.$cid))
				{
					// update the total number of comments on the mod page
					if(dbquery('UPDATE mods SET total_comments = (total_comments - 1) WHERE mid = '.$mod_id))
					{
						$jsn["OK"] = true;
					}
					else
					{
						// database error message
						$jsn["msg"] = "Could not update mod total comments, contact administration.";
					}
				}
				else
				{
					// database error message
					$jsn["msg"] = "Database error during comment remove. Refresh the page.";
				}
			}
			else
			{
				// someone is trying to delete a comment from another user | or is not an admin to remove 
				$jsn["msg"] = "This comment ID was not made by you!";
			}
		}
		else
		{
			// comment not found message
			$jsn["msg"] = "Comment not found, maybe it was removed.";
		}
		
		return $jsn;
	}
	
	// time elapsed function
	function time_elapsed($datetime, $full = false)
	{
		$now = new DateTime;
		$ago = new DateTime($datetime);
		
		$diff = $now->diff($ago);
		
		$diff->w = floor($diff->d / 7);
		$diff->d -= $diff->w * 7;
		
		$string = array('y' => 'year','m' => 'month','w' => 'week','d' => 'day','h' => 'hour','i' => 'minute','s' => 'second');
		
		foreach ($string as $k => &$v)
		{
			if ($diff->$k)
			{
				$v = $diff->$k . ' ' . $v . ($diff->$k > 1 ? 's' : '');
			}
			else
			{
				unset($string[$k]);
			}
		}
		
		if (!$full) $string = array_slice($string, 0, 1);
		return $string ? implode(', ', $string) . ' ago' : 'just now';
	}
	
	// load user comment tag
	function user_tag($rank, $by_id, $user_id)
	{
		if($rank == 2)
		{
			// admin tag
			$tag = "admin"; $name = "Admin";
		}
		elseif($by_id == $user_id)
		{
			// author tag
			$tag = "auth"; $name = "Author";
		}
		else
		{
			// normal user tag
			$tag = ""; $name = "";
		}
		
		return '<span class="utag" id="'.$tag.'_tag">'.$name.'</span>';
	}
	
	// admin - update mod item
	function adm_update_mod()
	{
		$jsn["OK"] = false;
		
		// check if mod exists in database
		$query = dbquery('SELECT mid FROM mods WHERE mid = '.$this->id);
		
		if($query->num_rows == 1)
		{
			// try to update mod information
			if(dbquery('UPDATE mods SET name = "'.$this->name.'", version = "'.$this->version.'", seo = "'.$this->seo.'", catid = '.$this->category.', description = "'.$this->description.'", author = "'.$this->author.'", file_id = "'.$this->file_id.'", front_image = "'.$this->front_image.'", images = "'.$this->images.'", status = '.$this->status.', downs = '.$this->downloads.', rej_reason = "'.$this->reason.'" WHERE mid = '.$this->id))
			{
				// success
				$jsn["OK"] = true;
			}
			else
			{
				// database error message
				$jsn["msg"] = "Database error during mod edition, please refresh the page and try again!";
			}
		}
		else
		{
			// invalid mod id message
			$jns["msg"] = "Mod ID was not found on database.";
		}
				
		return $jsn;
	}
}

?>