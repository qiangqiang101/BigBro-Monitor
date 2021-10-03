<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Activated.aspx.vb" Inherits="Activated" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admincontent" Runat="Server">
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
                        <asp:TableHeaderCell>Date Activated</asp:TableHeaderCell>
                        <asp:TableHeaderCell>License Key</asp:TableHeaderCell>
                        <asp:TableHeaderCell>HWID</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Device</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Actions</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </div>
        </div>
    </div>
    <!-- /.container-fluid -->

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

