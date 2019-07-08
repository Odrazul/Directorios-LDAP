$(document).ready(function () {
    $("#btnValidate").click(function () {
        var userJson = $("#txtUser").val();
        $.ajax({
            type: "POST",
            url: "/Home/ValidateLdapUser",
            data: { "user": userJson },
            success: function (result) {
                if (result) {
                    alert("Usuario existe");
                } else {
                    alert("Usuario No existe");
                }
            }
        });

    });
});