$(document).ready(function () {

    //Pessoa Jurídica
    //Clique em CNPJ, RS ou Telefone
    $('#btnCnpj, #btnRs, #btnTelPj').on('click', function (e) {

        var idClick = e.target.id;

        //Clicando em CNPJ
        if (idClick == "btnCnpj") {

            pjTransitionEffect();

            setTimeout(function () {
                
                $('#pjRs,#pjTelPj').hide();
                $('#pjCnpj').fadeIn(800);
                $('#txtCnpj').focus();

            }, 1000);

        }

        //Clicando em RS
        else if (idClick == "btnRs") {

            pjTransitionEffect();

            setTimeout(function () {

                $('#pjCnpj,#pjTelPj').hide();
                $('#pjRs').fadeIn(800);
                $('#txtRs').focus();

            }, 1000);

        }

        //Clicando em TelPj
        else if (idClick == "btnTelPj") {

            pjTransitionEffect();

            setTimeout(function () {

                $('#pjCnpj,#pjRs').hide();
                $('#pjTel').fadeIn(800);
                $('#txtTelPj').focus();

            }, 1000);

        }

    });

    //Fase Dois
    $('#btnCnpjPhaseTwo, #btnRsPhaseTwo, #btnTelPjPhaseTwo').on('click', function (e) {

        var idClick = e.target.id;

        if (idClick == "btnCnpjPhaseTwo") {

            cnpjClickPhaseTwo();

        }

        else if (idClick == "btnRsPhaseTwo") {

            rsClickPhaseTwo();

        }

        else if (idClick == "btnTelPjPhaseTwo") {

            telPjClickPhaseTwo();

        }

    });

    //Botão Voltar PJ
    $('#btnBackPj').on('click', function () {

        $('#btnPjPhaseTwo').hide();
        $('#btnDefaultPj').show();
        $('#divPj').removeClass('effect-sadie-2');
        $('div.grid-pj').removeClass('grid-pj-after');
        $('#divPj').addClass('effect-sadie');
        $('#divPf,#divVehicle,#divFtp').delay(1000).fadeIn(500);
        $('#pjCnpj,#pjRs,#pjTel').hide();
        $('#btnBackPj').hide();

    });

});