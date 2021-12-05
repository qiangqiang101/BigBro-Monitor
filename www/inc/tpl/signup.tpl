<div class="marg access">
   <div class="wbox">
      <center><h2>Signup</h2></center>
      <form class="signup_form" id="signup" style="padding:0px 50px;" onsubmit="return false;">
         <label>Username: <input name="username" class="w380" type="text" maxlength="25"></label>
         <label>Email: <input name="email" class="w380" type="text" maxlength="60"></label>
         <label>Password: <input name="pass1" maxlength="30" class="w380" type="password"></label>
         <label>Confirm Password: <input name="pass2" maxlength="30" class="w380" type="password"></label>
         <div id="terms">By clicking 'Register' you agree with our <a href="terms" target="_blank">Terms</a> and <a href="privacy" target="_blank">Privacy Policy</a>.</div>
         <input id="register_btn" type="button" value="Register" onclick="signup(this.form, this);">
      </form><br><br>
      <div class="not">Already registered ? <b><a href="login">Click here</a></b> to login!</div>
   </div>
   <style>.footer{text-align:center;}</style>
   <script>$('.signup_form input[type="text"], .signup_form input[type="password"]').on('keypress', function(e){ if(e.which === 13){ $("#register_btn").click();}});</script>
</div>