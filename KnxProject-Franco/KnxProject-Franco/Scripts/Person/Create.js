$(document).ready(function () {
    $('#PersonType').change(function () {
        selection = $(this).val();
        switch (selection) {
            case 'Lawyer':
                $('#Lawyer').show();
                $('#Employee').hide();
                $('#Client').hide();
                break;
            case 'Employee':
                $('#Employee').show();
                $('#Lawyer').hide();
                $('#Client').hide();
                break;
            case 'Client':
                $('#Client').show();
                $('#Lawyer').hide();
                $('#Employee').hide();
                break;
            default:
                $('#Lawyer').hide();
                $('#Employee').hide();
                $('#Client').hide();
                break;
        }
    })
});
