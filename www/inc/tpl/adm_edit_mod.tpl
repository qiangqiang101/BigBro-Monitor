<script src="assets/jquery-ui.min.js"></script>
<script>var MFS_UPLOAD = %mfs_upload%, MFS_IMAGE = %mfs_image%;</script>
<div class="marg default-gray upload">
   <h2 style="color: #fff";>Editing %mod_name%</h2>
   <div class="cf up_form">
      <form>
      <input type="hidden" name="mid" value="%mod_id%">
      <div class="lft">
         
         <div class="wbox mods_infos">
            <table>
               <tr>
                  <td style="padding-right:15px;"><b>File Name</b><input type="text" name="filename" value="%mod_name%"></td>
                  <td><b>Version <small>(optional)</small></b><input type="text" name="version" style="width:100px !important;" value="%version%"></td>
               </tr>
            </table>
            
            <b>Author</b>
            <input type="text" name="author" value="%author%" class="w420"><br>
            
            <b>Category</b>
            <select id="drop_cats" name="category" class="w420">
			   <option value="5">3.5 Inch</option>
               <option value="1">5 Inch</option>
               <option value="2">7 Inch</option>
               <option value="3">8 Inch</option>
               <option value="4">Misc</option>
            </select>
            <br>
            
            <b>Description</b>
            <textarea rows="10" class="w420" placeholder="Provide information and installation instructions if necessary..." name="description">%description%</textarea>
            <small>Allowed HTML tags: &lt;b&gt;, &lt;i&gt;, &lt;u&gt;, &lt;a&gt;, &lt;ul&gt;, &lt;ol&gt;, &lt;li&gt;</small>
            
         </div>
         
         <div class="wbox">
            <b>Upload your file</b> 
            <small>(.zip, .rar, .7z only; Maximum %mfs_upload%mb)</small>
            <input type="hidden" name="file_id" id="file_id" value="%file_id%">
            <input id="mod_file" type="file" onchange="pre_up_mod(this);" style="display:none;">
                        
            <div class="pre_up"></div>
            
            <div class="loading_up" id="gif_file">Uploading file...</div>
            
            <div class="file_res" style="display: block;">File uploaded: <a href="request/%file_id%" target="_blank">%file_id%</a> &nbsp;&nbsp;<small><a onclick="remove_up();">(remove)</a></small></div>
            
         </div>
         
         <div class="wbox">
            <div class="up_imgs">
               <b>Add screenshots</b>
               <small>(.jpg or .png only; Maximum %noi%; %mfs_image%mb each)</small>
               <input id="mod_images" type="file" accept="image/jpeg, image/png" onchange="upload_screenshot(this, %noi%);">
            </div>
            
            <div class="loading_up" id="gif_image">Uploading screenshot...</div>
            
            <div class="gallery cf">%gallery%</div>
         </div>
         
      </div>
      
      <div class="rgt">
      
         <div class="wbox emsets">
            <h3>Mod Settings</h3>
            <small>Here you can manage the mod settings.</small><br><br>
            
            <b>Mod ID</b>
            <input value="%mod_id%" readonly="readonly" type="text" style="width:150px;"><small>You can't change mod's ID.</small><br><br>
            
            <b>Mod Status</b>
            <select name="status" id="mod_status" onchange="status_change(this);"><option value="0">Pending</option><option value="1">Approved</option><option value="2">Rejected</option><option value="3">Pending (Resent)</option></select>
            <textarea name="reason" id="rej_reason" placeholder="Reject reason: why this mod was rejected ? This message will be shown to mod uploader, in the hope of correcting the problems." rows="7">%reason%</textarea>
            <br>
            
            <b>Mod SEO</b>
            <input name="seo" value="%mod_seo%" type="text"><small>Recommended not to touch.</small><br><br>
            
            <b>User Upload ID <small>(<a href="edit_user?uid=%user_id%" target="_blank">View User</a>)</small></b>
            <input type="text" value="%user_id%" style="width:150px;" readonly="readonly"><small>You can't change uploader's ID.</small><br><br>
            
            <b>Number of Downloads</b>
            <input name="downs" value="%downs%" type="text" style="width:150px;"><small>How many times this mod was downloaded.</small><br><br>
            
         </div>
                  
         <center><input type="button" value="Save Changes" class="up_btn" onclick="update_mod(this.form, this, 2);"> &nbsp; <a onclick="history.go(-1);" class="btn">Cancel</a></center>
         
         <div class="wbox" style="margin-top:25px;">
            <b>Delete Mod</b><br>
            The mod will be removed from database, including the users comments. There is no turning back!<br><br>
            <form>
               <input type="hidden" name="mid" value="%mod_id%">
               <label><input name="verify" type="checkbox"> Yes, I want to delete the mod forever<br><br></label>
               <input type="button" class="btn" onclick="delete_mod(this.form, this);" value="Delete">
            </form>
         </div>
         
      </div>
      </form>
   </div>
      
   <script>adm_editing_mode(%cat_id%, %mod_status%);</script>
</div>