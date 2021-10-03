// Call the dataTables jQuery plugin
$(document).ready(function () {
    $('#dataTable').DataTable({
        "language": {
            "lengthMenu": "<td>Display &nbsp</td><td> _MENU_ </td><td>&nbsp records</td>",
            "search": "<td>Search &nbsp</td><td> _INPUT_ </td>"
        },
        "lengthMenu": [[20, 40, 60, 100, 150, 200, -1], [20, 40, 60, 100, 150, 200, "All"]],
        "order": [[0, "desc"]]
    });
});
