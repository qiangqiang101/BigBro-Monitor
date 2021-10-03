<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="License.aspx.vb" Inherits="License" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admincontent" runat="Server">
    <!-- Begin Page Content -->
    <div class="container-fluid">

        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800">License</h1>

        <!-- DataTales Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">License</h6>
            </div>
            <div class="card-body">
                <asp:Table CssClass="table table-bordered table-hover" ID="dataTable" ClientIDMode="Static" Width="100%" CellSpacing="0" runat="server">
                    <asp:TableHeaderRow TableSection="TableHeader">
                        <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Date Created</asp:TableHeaderCell>
                        <asp:TableHeaderCell>License Key</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Actions</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
                <hr />
                <div class="form-group row">
                    <div class="col-sm-2 ml-auto">
                        <asp:Button class="btn btn-primary btn-user btn-block" href="#" data-toggle="modal" data-target="#mdlGenKey" ID="btnGenerateKeys" runat="server" Text="Generate Keys" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /.container-fluid -->

    <div class="modal fade" id="mdlGenKey" tabindex="-1" role="dialog" aria-labelledby="mdlGenKeylabel" aria-hidden="true">
        <div class="modal-dialog modal-sm" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="mdlGenKeylabel">Generate Keys</h5>
                    <button class="close" type="button" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">×</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group row">
                        <div class="col-sm-12 mb-3 mb-sm-0">
                            <label><b>No. of keys</b></label>
                            <asp:TextBox class="form-control form-control-user" ID="txtNumbers" runat="server" placeholder="0" required="Required" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button type="button" class="btn btn-primary" id="btnConfirmGen" runat="server">Generate</button>
                </div>
            </div>
        </div>
    </div>

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

