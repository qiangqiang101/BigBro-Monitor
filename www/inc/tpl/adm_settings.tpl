<div class="marg default-gray adm_settings">
   <h2 style="color: #fff";>Website Settings</h2>
   <div class="wbox">
   <form>
      <table>
         <tr><td>Site Name:</td><td><input type="text" value="%site_name%" name="site_name"></td></tr>
         <tr><td>Site Domain:</td><td><input type="text" value="%site_url%" name="site_domain"><small>Example: http://mysite.com/ - With the ending slash /</small></td></tr>
         <tr><td>Meta Description:</td><td><input type="text" value="%site_desc%" name="description"></td></tr>
         <tr><td>Meta Keywords:</td><td><input type="text" value="%site_keys%" name="keywords"></td></tr>
         <tr><td>Site Footer:</td><td><input type="text" value="%site_footer%" name="site_footer"></td></tr>
         <tr><td>Mods per Page:</td><td><input type="text" value="%mpp%" name="mpp" style="width:30px;" maxlength="3"><small>The number of mods that are shown per page.</small></td></tr>
         <tr><td>Comments per Loading:</td><td><input type="text" value="%cpl%" name="cpl" style="width:30px;" maxlength="3"><small>The number of comments that are loaded by each time.</small></td></tr>
         <tr><td>Max number of Images:</td><td><input type="text" value="%noi%" name="noi" style="width:30px;" maxlength="3"><small>The max number of mod images allowed to upload.</small></td></tr>
         <tr><td>Upload max file size:</td><td><input type="text" value="%mfs_upload%" name="max_upload" style="width:50px;" maxlength="3"> MB<small>The max file size in Megabytes of file uploading.</small></td></tr>
         <tr><td>Images max file size:</td><td><input type="text" value="%mfs_image%" name="max_image" style="width:50px;" maxlength="3"> MB<small>The max file size in Megabytes of images uploading.</small></td></tr>
         <tr><td></td><td><input type="button" value="Save Changes" onclick="save_web_settings(this.form, this);"></td></tr>
      </table>
   </form>
   </div>
   <div class="wbox up_limit">
      <h4>Server Upload Limit</h4>
      Current server file size upload limit is <a><b>%mfs_server%B</b></a>.<br>
      If you need to set higher values, edit parameter <a><b>upload_max_filesize</b></a> in PHP's ini configuration file.
   </div>
   
</div>