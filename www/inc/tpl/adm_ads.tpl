<div class="marg default-gray adm_ads">
   <h2 style="color: #fff";>Advertisements</h2>
   
   <div class="wbox">
   <form>
   <table>
      <tr><td>Ads Enabled:</td><td><select id="ads_status" name="enable_ads"><option value="1">Yes</option><option value="0">No</option></select></td></tr>
      <tr><td>Adsense Page-Level Ad Code:</td><td><textarea name="adsense_code">%adsense_code%</textarea><small>This code will be included inside the head tag.</small></td></tr>
      <tr><td><b>336x280</b> Ad Code:</td><td><textarea name="adcode1">%adm_ads_1%</textarea><small>This ad will be shown on the mod item and download pages.</small></td></tr>
      <tr><td><b>300x250</b> Ad Code:</td><td><textarea name="adcode2">%adm_ads_2%</textarea><small>This ad will be shown on home, profiles and mod categories pages.</small></td></tr>
      <tr><td><b>Responsive</b> Ad Code:</td><td><textarea name="adcode3">%adm_ads_3%</textarea><small>This ad will be shown on mod item page, on the top of mod gallery.</small></td></tr>
      <tr><td></td><td><input type="button" value="Save Changes" onclick="save_ads(this.form, this);"></td></tr>
   </table>
   </form>
   </div>
   <script>$('#ads_status').val(%ads_status%);</script>
</div>