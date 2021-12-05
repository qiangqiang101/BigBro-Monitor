<div class="marg default-gray settings">
   <script>var MFS_IMAGE = %mfs_image%;</script>
   <h2 style="color: #fff";>Settings</h2>
   <div class="cf">
      
      <div class="wlft">
         <div class="wbox s_menus">
            <a class="sel" menu-tab="account">Account</a>
            <a menu-tab="pass">Change Password</a>
            <a menu-tab="picture">Change Picture</a>
         </div>   
      </div>
      
      <div class="wrgt">
         <div class="wbox">
            
            <div id="s_account" class="s_divs">
               <h3>Account Settings</h3>
               <form onsubmit="return false;">
               <table>
                  <tr><td>Username:</td><td><input type="text" readonly="readonly" value="%username%"><small>You can't change your username.</small></td></tr>
                  <tr><td>Email:</td><td><input type="text" readonly="readonly" value="%email%"><small>You can't change your email.</small></td></tr>
                  <tr><td>Location:</td><td><input type="text" name="location" maxlength="70" value="%location%"></td></tr>
                  <tr><td>Website:</td><td><input type="text" name="website" maxlength="100" value="%website%"></td></tr>
                  <tr><td>About Me:</td><td><textarea name="about_me" maxlength="300">%about_me%</textarea></td></tr>
                  <tr><td></td><td><input type="button" value="Save Changes" onclick="update_account(this.form, this);"></td></tr>
               </table>
               </form>
            </div>
            
            <div id="s_pass" class="s_divs" style="display:none;">
               <h3>Change Password</h3>
               <form onsubmit="return false;" id="cpass_form">
               <input id="cpass_key" type="hidden" name="cpass" value="%cpass%">
               <table>
                  <tr><td>Current Password:</td><td><input type="password" name="pass0"></td></tr>
                  <tr><td>New Password:</td><td><input type="password" name="pass1" maxlength="25"><small>Your new password must have at least 6 characters.</small></td></tr>
                  <tr><td>Repeat New Password:</td><td><input type="password" name="pass2" maxlength="25"></td></tr>
                  <tr><td></td><td><input type="button" value="Save Password" onclick="change_password(this.form, form);"></td></tr>
               </table>
               </form>
            </div>
            
            <div id="s_picture" class="s_divs" style="display:none;">
               <h3>Change Picture</h3>
               <form>
               <table>
                  <tr>
                     <td><img src="%site_url%uploads/avatars/%avatar%_thumb.jpg" width="75" id="pic_preview"></td>
                     <td>Upload a custom profile picture<br><small>(.jpg or .png only; Maximum %mfs_image%mb; Recommended 256x256 pixels)</small><br><input id="prof_pic" name="file" type="file" accept="image/jpeg, image/png"></td>
                  </tr>
                  <tr><td></td><td><br><input type="button" value="Save" onclick="update_picture(this);"></td></tr>
               </table>
               </form>
            </div>
            
         </div>
      </div>
      
   </div>
</div>
<script>bind_settings_menus();</script>