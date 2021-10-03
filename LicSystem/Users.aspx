<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Users.aspx.vb" Inherits="Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admincontent" runat="Server">
    <!-- Begin Page Content -->
    <div class="container-fluid">

        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800">User</h1>

        <!-- DataTales Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">Users</h6>
            </div>
            <div class="card-body">
                <asp:Table CssClass="table table-bordered table-hover" ID="dataTable" ClientIDMode="Static" Width="100%" CellSpacing="0" runat="server">
                    <asp:TableHeaderRow TableSection="TableHeader">
                        <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                        <asp:TableHeaderCell>User Name</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Full Name</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Date Created</asp:TableHeaderCell>
                        <asp:TableHeaderCell>User Type</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Status</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Actions</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
                <hr />
                <div class="form-group row">
                    <div class="col-sm-2 ml-auto">
                        <asp:Button class="btn btn-primary btn-user btn-block" href="#" data-toggle="modal" data-target="#mdlAddUser" ID="btnAddUser" runat="server" Text="Add User" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /.container-fluid -->
    <asp:ScriptManager runat="server" />

    <div class="modal fade" id="mdlAddUser" tabindex="-1" role="dialog" aria-labelledby="mdlAddUserlabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Add User</h5>
                    <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group row">
                        <div class="col-sm-6 mb-3 mb-sm-0">
                            <label><b>User Name</b></label>
                            <asp:TextBox class="form-control form-control-user" ID="txtUserName" runat="server" placeholder="User ID" required="Required"></asp:TextBox>
                        </div>
                        <div class="col-sm-6">
                            <label><b>Password</b></label>
                            <asp:TextBox class="form-control form-control-user" ID="txtPassword" runat="server" placeholder="Password" required="Required"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-6 mb-3 mb-sm-0">
                            <label><b>Email</b></label>
                            <asp:TextBox class="form-control form-control-user" ID="txtEmail" runat="server" placeholder="Email" required="Required"></asp:TextBox>
                        </div>
                        <div class="col-sm-6">
                            <label><b>Full Name</b></label>
                            <asp:TextBox class="form-control form-control-user" ID="txtFullName" runat="server" placeholder="Full Name" required="Required"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-6 mb-3 mb-sm-0">
                            <label><b>User Enable</b></label>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList CssClass="form-control form-control-user" ID="cmbEnable" AutoPostBack="True" runat="server" placeholder="">
                                        <asp:ListItem Value="True">Enabled</asp:ListItem>
                                        <asp:ListItem Value="False">Disabled</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary" id="btnSubmit" runat="server">Submit</button>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="mdlEditUser" tabindex="-1" role="dialog" aria-labelledby="mdlEditUserlabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Edit User</h5>
                    <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group row">
                        <div class="col-sm-6 mb-3 mb-sm-0">
                            <label><b>User Name</b></label>
                            <asp:TextBox class="form-control form-control-user" ID="txtUserNameE" runat="server" placeholder="User ID" required="Required"></asp:TextBox>
                        </div>
                        <div class="col-sm-6">
                            <label><b>Password</b></label>
                            <asp:TextBox class="form-control form-control-user" ID="txtPasswordE" runat="server" placeholder="Password" required="Required"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-6 mb-3 mb-sm-0">
                            <label><b>Email</b></label>
                            <asp:TextBox class="form-control form-control-user" ID="txtEmailE" runat="server" placeholder="Email" required="Required"></asp:TextBox>
                        </div>
                        <div class="col-sm-6">
                            <label><b>Full Name</b></label>
                            <asp:TextBox class="form-control form-control-user" ID="txtFullNameE" runat="server" placeholder="Full Name" required="Required"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-6 mb-3 mb-sm-0">
                            <label><b>User Enable</b></label>
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList CssClass="form-control form-control-user" ID="cmbEnableE" AutoPostBack="True" runat="server" placeholder="">
                                        <asp:ListItem Value="True">Enabled</asp:ListItem>
                                        <asp:ListItem Value="False">Disabled</asp:ListItem>
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary" id="btnSubmitE" runat="server">Submit</button>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function openModal() {
            $('#mdlEditUser').modal('show');
        }
    </script>

    <!-- Bootstrap core JavaScript-->
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Core plugin JavaScript-->
    <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

    <!-- Custom scripts for all pages-->
    <script src="js/sb-admin-2.min.js"></script>

    <!-- Page level plugins -->
    <script src="vendor/datatables/jquery.dataTables.min.js"></script>
    <script src="vendor/datatables/dataTables.bootstrap4.min.js"></script>

    <!-- Page level custom scripts -->
    <script src="js/demo/datatables-demo.js"></script>
</asp:Content>

