<div class="marg dashboard">
   <h2 style="color: #fff";>Welcome to BigBro Monitor Administration Panel</h2>
   
   <div class="cf">
   
      <div class="wlft">
         <div class="wbox">
            <h3>Website Statistics</h3>
            <table>
               <tr><td>modsCMS Version:</td><td>v1.1</td></tr>
               <tr><td>Total of Mods:</td><td>%total_mods%</td></tr>
               <tr><td>Total of Users:</td><td>%total_users%</td></tr>
               <tr><td>Total of Comments:</td><td>%total_comments%</td></tr>
            </table>
         </div>
         
         <div class="wbox admins_list">
            <h3>Administrators</h3><br>
            %admins%
         </div>
      </div>
      
      <div class="wrgt">
         <div class="wbox">
            <h3>Admin Notes</h3>
            <br>
            <form>
               <textarea name="notes" class="admin_notes" placeholder="You can use this section to keep notes for yourself or other administrators..">%notes%</textarea>
               <input type="button" value="Save Notes" onClick="save_notes(this.form, this);">
            </form>
         </div>
      </div>
   </div>
</div>