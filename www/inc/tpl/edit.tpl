<script src="assets/jquery-ui.min.js"></script>
<script>var mod_seo = "%mod_seo%", MFS_UPLOAD = %mfs_upload%, MFS_IMAGE = %mfs_image%;</script>
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
               <option value="1">Characters</option>
               <option value="2">Objects</option>
               <option value="3">Maps</option>
               <option value="4">Vehicles</option>
               <option value="5">Weapons</option>
               <option value="6">Scripts</option>
               <option value="7">Tools</option>
               <option value="8">Misc</option>
            </select>
            <br>
            
            <b>Description</b>
            <textarea rows="10" class="w420" placeholder="Provide information and installation instructions if necessary..." name="description">%description%</textarea>
            <small>Allowed HTML tags: &lt;b&gt;, &lt;i&gt;, &lt;u&gt;, &lt;a&gt;, &lt;ul&gt;, &lt;ol&gt;, &lt;li&gt;</small>
            
         </div>
         
      </div>
      
      <div class="rgt">
         
         %reject_div%
      
         <div class="wbox">
            <b>Upload your file</b> 
            <small>(.zip, .rar, .7z only; Maximum %mfs_upload%mb)</small>
            <input type="hidden" name="file_id" id="file_id" value="%file_id%">
            <input id="mod_file" type="file" onchange="pre_up_mod(this);" style="display:none;">
                        
            <div class="pre_up"></div>
            
            <div class="loading_up" id="gif_file">Uploading file...</div>
            
            <div class="file_res" style="display: block;">File uploaded: %file_id% &nbsp;&nbsp;<small><a onclick="remove_up();">(remove)</a></small></div>
            
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
         
         <input type="button" value="Save Changes" class="up_btn" onclick="update_mod(this.form, this, %ebtn_id%);"> &nbsp; <a onclick="history.go(-1);" class="btn">Cancel</a>
         
      </div>
      </form>
   </div>
   
   <div class="rules">
      <div class="wbox">
         <h3>Upload Rules</h3>
         <b>DO NOT upload any of the following items - breaking these rules will cause your file to be deleted without notice:</b>
         <ul>
            <li>Any files besides .zip, .rar, .7z archives</li>
            <li>Any file you don't have permission to upload, including part of other mods or mod packs</li>
            <li>Any archive containing only original game files</li>
            <li>Any file that can be used for cheating online</li>
            <li>Any file containing or giving access to pirated or otherwise copyrighted content including game cracks, movies, television shows and music</li>
            <li>Any file containing a virus or malware or any EXE file with a positive anti-virus result</li>
            <li>Any file containing nude or semi-nude pornographic images</li>
            <li>Any file depicting a political figure or ideology that is, at the complete discretion of the administrator, deemed to be something that will cause unnecessary debates in the comments section</li>
         </ul>
      </div>
   </div>
   <script>$(".gallery").sortable();$(".gallery").disableSelection(); $('#drop_cats').val(%cat_id%);</script>
</div>