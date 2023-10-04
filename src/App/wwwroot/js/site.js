function SetModal() {

    $(document).ready(function () {
        $(function () {
            $.ajaxSetup({ cache: false });

            $("a[data-modal]").on("click",
                function (e) {
                    $('#myModalContent').load(this.href,
                        function () {
                            $('#myModal').modal('show');
                            bindForm(this);
                        });
                    return false;
                });
        });
    });
}

function bindForm(dialog) {
    $('form', dialog).submit(function () {
        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (result) {
                if (result.success) {
                    $('#myModal').modal('hide');
                    $('#AddressTarget').load(result.url); // Carrega o resultado HTML para a div demarcada
                } else {
                    $('#myModalContent').html(result);
                    bindForm(dialog);
                }
            }
        });
        SetModal();
        return false;
    });
}

function searchZipCode() {
    $('form', dialog).submit(function () {
        $.ajax({
            url: this.action,
            type: this.method,
            data: $(this).serialize(),
            success: function (result) {
                if (result.success) {
                    $('#myModal').modal('hide');
                    $('#EnderecoTarget').load(result.url); // Carrega o resultado HTML para a div demarcada
                } else {
                    $('#myModalContent').html(result);
                    bindForm(dialog);
                }
            }
        });

        SetModal();
        return false;
    });
}

function SearchZipCode() {
    $(document).ready(function () {

        function ClearForm() {
            $("#Address_Street").val("");
            $("#Address_District").val("");
            $("#Address_City").val("");
            $("#Address_State").val("");
        }


        $("#Address_ZipCode").blur(function () {

            var zipCode = $(this).val().replace(/\D/g, '');
            var zip1 = zipCode.slice(0, 4);
            var zip2 = zipCode.slice(4);

            console.log(zipCode);
            console.log(zip1);
            console.log(zip2);

            if (zipCode != "") {

                var validateZipCode = /^[0-9]{7}$/;

                if (validateZipCode.test(zipCode)) {

                    $.getJSON("https://json.geoapi.pt/codigo_postal/" + zip1 + "-" + zip2)
                        .done(function (data) {
                            if (data.Localidade) {
                                $("#Address_District").val(data.Localidade);
                                $("#Address_City").val(data.Concelho);
                                $("#Address_State").val(data.Distrito);
                            } else {
                                ClearForm();
                                alert("Ocorreu um erro inesperado.");
                            }
                        })
                        .fail(function () {
                            ClearForm();
                            alert("Código postal não encontrado.");
                        });
                }
            }
            else {
                ClearForm();
            }
        });
    });
}
