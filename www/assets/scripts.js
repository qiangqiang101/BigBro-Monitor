// modal box script
var modal = {
	
	close_btn:'<input onClick="modal.end();" id="m-close" type="button" value="X">',
	
	start:function(mTitle, mBody, mWidth, mHeight, mBtnx)
	{
		var x_button = '';
		if(mBtnx){ x_button = modal.close_btn; }
		
		$('.modal').css({"width":mWidth + "px", "height": mHeight +"px"});
		$('.modal .m-title').html(mTitle + x_button);
		$('.modal .m-body').html(mBody);
		$('.modal-bg').show();
		
	},
	
	title:function(txt, btnx)
	{
		var x_button = '';		
		if(btnx){ x_button = modal.close_btn; }
		
		$('.modal .m-title').html(txt + x_button);
	},
	
	html:function(new_html)
	{
		$('.modal .m-body').html(new_html);
	},
	
	end:function()
	{
		$('.modal-bg').fadeOut("fast", function(){ $('.modal .m-title, .modal .m-body').html(''); });
	},
	
	msg:function(mtitle, mbody)
	{
		modal.start(mtitle, mbody, 350, 150, true);
	}
}

// ajax function
function ajaxify(aid, rtype, sendData, before, after)
{
	$.ajax({method: "POST", url: "ajax", dataType:rtype, data: "aid="+ aid + "&" + sendData, beforeSend: function(){ before();}, success: function(result){ after(result); }, error:function(result){ modal.msg("AJAX Error", "There was an error during the ajax request, please, refresh the page or contact the administration team."); $("body").css("cursor", "default"); }});
}

function call(aid, form, btn, success)
{
	var btn_text = $(btn).val();
	
	btn_load(btn, false, btn_text);
	
	ajaxify(aid, "json", $(form).serialize(),
		function()
		{
			btn_load(btn, true, " ");
		},
		function(res)
		{
			btn_load(btn, false, btn_text);
			success(res);
			
		});
}

function btn_load(btn, is_loading, text)
{
	$(btn).val(text);
	
	if(is_loading)
	{
		$(btn).addClass("loading");
		$(btn).attr("disabled", "disabled");
		$("body").css("cursor", "progress");
	}
	else
	{
		$(btn).removeClass("loading");
		$(btn).removeAttr("disabled");
		$("body").css("cursor", "default");
	}
}

// add blue bottom border to a selected category by it's ID
function sel_category(cat_id)
{
	$("#c_" + cat_id).addClass("sel");
}

// offline upload button - show login message in modal
function must_login()
{
	modal.msg("Login First",'You must be logged to upload, <a href="login">click here</a> to login.');
}

// open image from a url
function open_image(url)
{
	big_loader(true);
	$('.img-viewer').show();
	var image = new Image();
	
	image.onload = function(){  big_loader(false); $('.img-viewer').html('<img src="'+ url +'">').show(); }
	image.onerror = function(){ big_loader(false); close_img(); alert('Could not load the image, try to refresh the page.'); }
	
	image.src = url;
}

// open image from a url, short code
function oia(url)
{
	open_image(url);
}
 
// open image from div
function oid(div)
{
	var bg = $(div).css('background-image');
	bg = bg.replace('url(','').replace(')','').replace(/\"/gi, "");
	
	open_image(bg);	
}

// close image viewer
function close_img()
{
	$('.img-viewer').fadeOut("fast").html("");
}

function key_seo(value)
{
	$('#seo_field').val(seo_url(value));
}

function seo_url(url)
{
	var eurl = url.toString().toLowerCase();
	eurl = eurl.split(/\&+/).join("-and-");
	eurl = eurl.split(/[^a-z0-9]/).join("-");
	eurl = eurl.split(/-+/).join("-");
	eurl = eurl.trim('-'); 
	return eurl; 
}

//////////////////////////////////////////////////////////////////////////////////////////

function login(form, btn)
{
	call(1, form, btn, function(res){ if(res.OK){ window.location = "home"; } else { modal.msg("Oops...", res.msg); } });
}

function signup(form, btn)
{
	call(2, form, btn, function(res){ if(res.OK){ window.location = "created"; } else { modal.msg("Oops...", res.msg); } });
}

function update_account(form, btn)
{
	call(3, form, btn, function(res){ modal.msg("Update Account", res.msg + '<br><br><a onclick="modal.end();" class="btn">Ok</a>'); });
}

function change_password(form, btn)
{
	call(4, form, btn, function(res)
	{
		if(res.pass != "")
		{
			$('#cpass_form input[type="password"]').val("");
			$('#cpass_key').val(res.pass);
		}
		
		modal.msg("Change Password", res.msg);
	});
}

function update_picture(btn)
{
	var btn_text = $(btn).val();
	
	btn_load(btn, false, btn_text);
	
	upload_image(5, "#prof_pic", function(){ btn_load(btn, true, " "); },
	function(res)
	{
		if(res.OK)
		{
			$("#pic_preview, #avatar_pic").attr("src", res.url);
		}
		else
		{
			modal.msg("Change Picture", res.msg);
		}
		
		btn_load(btn, false, btn_text);
		
	});
}

function load_gif(input, loading, gif_id)
{
	if(loading)
	{
		$("#gif_" + gif_id).show();
		$(input).attr("disabled", "disabled");
		$(".upload .up_btn").attr("disabled", "disabled");
		$("body").css("cursor", "progress");
	}
	else
	{
		$("#gif_" + gif_id).hide();
		$(input).removeAttr("disabled");
		$(".upload .up_btn").removeAttr("disabled");
		$("body").css("cursor", "default")
	}
}

function upload_screenshot(input, maximum)
{
	load_gif(input, false, "image");
	
	if($(".gallery .uimg").length  >= maximum)
	{
		modal.msg("Oops!", "The image limit has been reached.");
		$(input).val("");
	}
	else
	{
		upload_image(6, input,
		function(){
			load_gif(input, true, "image");
		},
		function(res){
			
			load_gif(input, false, "image");
			
			if(res.OK)
			{
				image_preview_html(res.img_id, res.img_url);
			}
			else
			{
				modal.msg("Oops", res.msg);
			}			
		});
	}
}

function image_preview_html(img_id, img_url)
{
	var h = '<div class="uimg ui_'+ img_id +'">';
	    h += '<div class="img_prev" style="background-image:url('+ img_url+');"></div>';
		h += '<input type="hidden" name="imgPic[]" value="'+ img_id +'">';
		h += '<input type="button" value="Remove" class="remove_btn" onclick="rip(\'' + img_id + '\');">';
		h += '</div>';
		
	$(".gallery").append(h);
}

function rip(img_id)
{
	$(".gallery .ui_" + img_id).remove();
}

function bytesToSize(bytes) {
    
	var sizes = ['Bytes', 'KB', 'MB', 'GB', 'TB'];
    if (bytes == 0) return 'n/a';
    
	var i = parseInt(Math.floor(Math.log(bytes) / Math.log(1024)));
    if (i == 0) return bytes + ' ' + sizes[i];
	
    return (bytes / Math.pow(1024, i)).toFixed(1) + ' ' + sizes[i];
};

function pre_up_mod(input)
{
	var file = $(input)[0].files[0];
	
	var h = '<div class="pre_up_box">';
	    h += 'Are you sure you want to upload the file:<br>';
	    h += '<ul>';
		h += '<li>Name: <b>'+ file.name +'</b></li>';
		h += '<li>Size: <b>'+ bytesToSize(file.size) +'</b></li>';
		h += '<br><a class="btn up_btn" onclick="upload_mfile(\'#mod_file\');">Yes</a> <a class="btn" onclick="cancel_pre_up();">No</a>';
		h += '</ul>';
		h += '</div>';
	
	$(".pre_up").html(h).show();
}

function cancel_pre_up()
{
	$(".pre_up").hide().html("");
	$("#mod_file").val("");
}

function upload_mfile(input)
{
	$(".pre_up").hide().html("");
	load_gif(input, false, "file");
	
	upload_file(7, input,
	function()
	{
		load_gif(input, true, "file");
	},
	function(res)
	{
		load_gif(input, false, "file");
		
		if(res.OK)
		{
			$("#mod_file").hide();
			$("#file_id").val(res.file_id);
			
			$(".file_res").html('File uploaded: <a href="request/'+ res.file_id +'" target="_blank">'+ res.file_id +'</a> &nbsp;&nbsp;<small><a onclick="remove_up();">(remove)</a></small>').fadeIn();
		}
		else
		{
			modal.msg("Oops", res.msg);
		}
	});
}

function remove_up()
{
	$(".file_res").fadeOut(function(){ $(this).html(""); $("#file_id").val(""); $('#mod_file').fadeIn(); });
}

function upload(form, btn)
{
	if($("#file_id").val().trim() == "")
	{
		modal.msg("Upload a File", "You should upload a file.");
	}
	else if($(".gallery .uimg").length == 0)
	{
		modal.msg("Upload a Screenshot", "You should upload at least one screenshot.");
	}
	else
	{
		call(8, form, btn, 
		function(res){
			if(res.OK)
			{
				window.location = "my_uploads";
			}
			else
			{
				modal.msg("Oops", res.msg);
			}
		});
	}
}

function update_mod(form, btn, up_type)
{
	switch(up_type)
	{
		case 1:
		   var AID = 12;
		   var success = 'Your mod was successfully edited!<br><br><a href="view/'+ mod_seo +'" class="btn up_btn">OK</a>';
		break;
		
		case 2:
		   var AID = 16;
		   var success = 'The mod was successfully updated!<br><br><a class="btn up_btn" onclick="modal.end();">OK</a>';
		break;
		
		case 3:
		   var AID = 12;
		   var success = 'Your mod was successfully edited!<br><br><a href="my_uploads" class="btn up_btn">OK</a>';
		break;
	}
	
	if($("#file_id").val().trim() == "")
	{
		modal.msg("Upload a File", "You should upload a file.");
	}
	else if($(".gallery .uimg").length == 0)
	{
		modal.msg("Upload a Screenshot", "You should upload at least one screenshot.");
	}
	else
	{
		call(AID, form, btn,
		function(res)
		{
			if(res.OK)
			{
				modal.start("Success!", '<center><img src="assets/images/ok.png" width="100"><br><br>'+ success +'</center>', 370, 300, false);
			}
			else
			{
				modal.msg("Oops", res.msg);
			}
		});
	}
}

function jsonUnescape(str){ return str.replace(/\\r\\n/g, "<br>").replace(/\\'/g, "'"); }

function add_comment(form, btn)
{
	call(9, form, btn,
	function(res)
	{
		if(res.OK)
		{
			var total_comments = parseInt($('#total_comments').text());
			
			$('#total_comments').text(total_comments + 1);
			$("#comments_text textarea").val("");
			$(".comments_list").append(jsonUnescape(res.htmlt));
			$("html, body").animate({ scrollTop: $(document).height() }, 1000);
		}
		else
		{
			modal.msg("Oops", res.msg)
		}
	});
}


// load more comments
function lm_comments(mod_id, btn)
{
	var btn_text = "Load More Comments";
	var last_id = $(".comments_list .comm").first().attr("id").replace("cm_id_","");
	
	btn_load(btn, false, btn_text);
	
	ajaxify(10, "json", "mod_id=" + mod_id + "&last_id=" + last_id,
	function()
	{
		btn_load(btn, true, " ");
	},
	function(res)
	{
		if(res.OK)
		{
			if(res.html == "")
			{
				$("#lmc_btn").remove();
			}
			else
			{
				$(".comments_list").prepend(res.html);
			}
		}
		else
		{
			modal.msg("Oops!", res.msg);
		}
		
		btn_load(btn, false, btn_text);
		
	});	
}

function big_loader(loading)
{
	if(loading)
	{
		$(".big-loader").show();
	}
	else
	{
		$(".big-loader").hide();
	}
}

function remove_comment(cid)
{
	var res = confirm("Do you want to delete the comment ?");
	
	if(res)
	{
		ajaxify(11, "json", "cid="+cid,
		
		function(){
			big_loader(true);
		},
		function(response){
			
			big_loader(false);
			
			if(response.OK)
			{
				var total_comments = parseInt($('#total_comments').text());
				$('#total_comments').text(total_comments - 1);
				$('#cm_id_' + cid).fadeOut();
			}
			else
			{
				modal.msg("Oops", response.msg);
			}			
		});
	}
}

function save_notes(form, btn)
{
	call(13, form, btn, function(res){ modal.msg("Admin Notes", res.msg); });
}

function save_web_settings(form, btn)
{
	call(14, form, btn, function(res){ modal.msg("Message", res.msg); });
}

function save_ads(form, btn)
{
	call(15, form, btn, function(res){ modal.msg("Message", res.msg); });
}

function update_user(form, btn)
{
	call(17, form, btn, function(res){ modal.msg("Message", res.msg); });
}

function delete_mod(form, btn)
{
	call(18, form, btn, function(res)
	{
		if(res.OK)
		{
			$('.upload').html('<h2>Removed!</h2>The mod and it\'s comments were successfully removed!<br><br><a class="btn" href="adm_mods">Ok &raquo;</a>');
		}
		else
		{
			modal.msg("Message", res.msg);
		}
	});
}

function adm_editing_mode(cat_id, mod_status)
{
	// gallery drag
	$(".gallery").sortable();$(".gallery").disableSelection(); 
	
	// mod category select
	$('#drop_cats').val(cat_id);
	
	// mod status select
	$('#mod_status').val(mod_status);
	
	if(mod_status == 2 || mod_status == 3)
	{
		$("#rej_reason").show();
	}
}

function status_change(el)
{
	var status = $(el).val();
	
	if(status == 2 || status == 3)
	{
		$("#rej_reason").show();
	}
	else
	{
		$("#rej_reason").hide().val("");
	}
}

function default_avatar(el)
{
	$("#avatar_id").val("default");
	$("#avatar_pic").attr("src", "uploads/avatars/default_thumb.jpg");
	$(el).remove();
}

function wait()
{
	modal.msg("Under Review", "Your mod is under review.<br>This might take some hours!");
}

//////////////////////////////////////////////////////////////////////////////////////////
 
function mbtob(mb)
{
	var mb = mb.toString().replace(/[^\d\.eE-]/g,'');
	
	if (mb * 1048576 != 0){ mb = (mb * 1048576); }
	
	return parseInt(mb);
}

function upload_image(aid, from, before, after)
{
	var file = $(from)[0].files[0];
	
	if(file == null)
	{
		modal.msg("Error", "File can't be empty.");
		$(from).val("");
	}
	else if(!(/\.(jpg|jpeg|png)$/i).test(file.name))
	{
		modal.msg("Error", "You must select a valid image type (JPEG, JPG, PNG).");
		$(from).val("");
	}
	else if(file.size > mbtob(MFS_IMAGE))
	{
		modal.msg("Error", "Your image file size can't be more than "+ MFS_IMAGE +" MB.");
		$(from).val("");
	}
	else
	{	
		var reader = new FileReader();
		reader.onloadend = function(){
			
			
			var image = new Image();

			image.src = reader.result;			
			image.onload = function(){
				
				var MAX_HEIGHT = 900;
				var canvas = document.createElement('canvas');
				
				if(image.height > MAX_HEIGHT) {
					image.width *= MAX_HEIGHT / image.height;
					image.height = MAX_HEIGHT;
				}
				
				canvas.width = image.width;
				canvas.height = image.height;
				
				var ctx = canvas.getContext("2d");
				
				ctx.drawImage(this, 0, 0, image.width, image.height);
				
				var dataURL = canvas.toDataURL("image/jpeg");
				
				$.ajax({type: "POST", processData: true, contentType: "application/x-www-form-urlencoded", url: "ajax", data: "aid="+ aid +"&image=" + dataURL, dataType: "json", beforeSend: function(){ before(); }, success:function(response){ $(from).val(""); after(response); },
				error: function(e){ $(from).val(""); modal.msg("Error", "An error occurred during image upload, refresh the page."); } });
			}
		}
		reader.readAsDataURL(file);
	}
}

function upload_file(aid, from, before, after)
{
	var file = $(from)[0].files[0];
	
	if(file == null)
	{
		modal.msg("Error", "File can't be empty.");
		$(from).val("");
	}
	else if(!(/\.(rar|zip|7z)$/i).test(file.name))
	{
		modal.msg("Error", "You must select a valid file (RAR, ZIP, 7Z).");
		$(from).val("");
	}
	else if(file.size > mbtob(MFS_UPLOAD))
	{
		modal.msg("Error", "File size can't be more than "+ MFS_UPLOAD +" MB.");
		$(from).val("");
	}
	else
	{
		var sendData = new FormData();
		sendData.append("aid", 7);
		sendData.append("file", file);
		
		$.ajax({url : "ajax", type : "POST", data :sendData, processData: false, contentType: false, dataType:"json",
		   beforeSend:function()
		   {
			   before();
		   },
		   success:function(response)
		   {
			   $(from).val("");
			   after(response);
		   },
		   error:function(e)
		   {
			   $(from).val(""); modal.msg("Error", "An error occurred during file upload, refresh the page.");
		   }
		});
	}
}

//////////////////////////////////////////////////////////////////////////////////////////

function bind_settings_menus()
{
	var href = ".settings .s_menus a";
	$(href).on("click", function()
	{
		var tab = $(this).attr("menu-tab");
		$(href).removeClass("sel");
		$(this).addClass("sel");
		$('.settings .s_divs').hide();
		$('.settings #s_'+tab).show();
	});
}

$(window).on('scroll', function() {
    scrollPosition = $(this).scrollTop();
    if (scrollPosition >= 50){
		$(".top").css("box-shadow", "0 1px 5px rgba(85, 85, 85, 0.15)");
    } else {
		$(".top").css("box-shadow", "none");
	}
});