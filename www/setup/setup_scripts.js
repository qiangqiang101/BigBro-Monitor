function cmd(aid, form){
	$.ajax({method: "POST", url: "cmd.php", dataType:"json", data: "aid="+ aid + "&" + $(form).serialize(),
		beforeSend: function()
		{
			$(".msg").fadeOut();
			$("input[type=button]").attr("disabled", "disabled");
			$("#loading").show();
		}}).done(function(res)
		{
			if(res.OK){ redir("index.php?step="+(aid + 1)); }
			else { $("#loading").hide(); $("input[type=button]").removeAttr("disabled"); $(".msg").html(res.msg); $(".msg").fadeIn(); }
		}); 
}

function redir(url){ window.location.href = url; }