<div class="marg default-gray edit_user">
   <h2 style="color: #fff";>Editing <b><a href="user/%user_username%" target="_blank">%user_username%</a></b> <a class="btn" target="_blank" style="vertical-align:top; margin-left:10px;" href="uploads_by/%user_username%">View Mods &raquo;</a></h2>
   <div class="wbox">
      <form>
      <input type="hidden" name="uid" value="%user_id%">
      <table>
         <tr><td>User ID:</td><td><b>%user_id%</b></td></tr>
         <tr><td>Username:</td><td><b><a href="user/%user_username%" target="_blank">%user_username%</a></b></td></tr>
         <tr><td>Email:</td><td><b>%email%</b></td></tr>
         <tr><td>Rank:</td><td><select id="user_rank" name="rank"><option value="0">Banned</option><option value="1">User</option><option value="2">Administrator</option></select></td></tr>
         <tr><td>Location:</td><td><input type="text" name="location" value="%location%"></td></tr>
         <tr><td>About Me:</td><td><textarea rows="6" name="about">%about%</textarea></td></tr>
         <tr><td>Website:</td><td><input type="text" name="website" value="%website%"></td></tr>
         <tr><td>Avatar ID:</td><td><img src="uploads/avatars/%avatar%_thumb.jpg" id="avatar_pic"> <input type="text" id="avatar_id" name="avatar" value="%avatar%"> <small><a onclick="default_avatar(this);">(remove)</a></small></td></tr>
         <tr><td>IP Address:</td><td><b>%ip_address%</b></td></tr>
         <tr><td>Join Date:</td><td><b>%join_date%</b></td></tr>
         <tr><td></td><td><input type="button" value="Save Changes" onclick="update_user(this.form, this);"> or <a href="adm_users">Cancel</a></td></tr>
      </table>
      </form>
   </div>
   <script>$("#user_rank").val(%rank%);</script>
</div>