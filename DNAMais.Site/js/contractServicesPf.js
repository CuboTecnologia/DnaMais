$(document).ready(function () {

    //Pessoa Física
    //Clique em CPF, Endereço, Nome ou Telefone
    $('#btnCpf, #btnAddr, #btnName, #btnTel').on('click', function (e) {

        var idClick = e.target.id;

        //Clicando em CPF
        if (idClick == "btnCpf") {

            pfTransitionEffect();

            setTimeout(function () {

                $('#pfAddr,#pfName,#pfTel').hide();
                $('#pfCpf').fadeIn(800);
                $('#txtCpf').focus();

            }, 1000);

        }

        //Clicando em Endereço
        else if (idClick == "btnAddr") {

            pfTransitionEffect();

            setTimeout(function () {

                $('#pfCpf,#pfName,#pfTel').hide();
                $('#pfAddr').fadeIn(800);
                $('#txtAddr').focus();

            }, 1000);

        }

        //Clicando em Nome
        else if (idClick == "btnName") {

            pfTransitionEffect();

            setTimeout(function () {

                $('#pfCpf,#pfAddr,#pfTel').hide();
                $('#pfName').fadeIn(800);
                $('#txtName').focus();

            }, 1000);

        }

        //Clicando em Telefone
        else if (idClick == "btnTel") {

            pfTransitionEffect();

            setTimeout(function () {

                $('#pfCpf,#pfName,#pfAddr').hide();
                $('#pfTel').fadeIn(800);
                $('#txtTel').focus();

            }, 1000);

        }

    });

    //Fase Dois
    $('#btnCpfPhaseTwo, #btnAddrPhaseTwo, #btnNamePhaseTwo, #btnTelPhaseTwo').on('click', function (e) {

        var idClick = e.target.id;

        if (idClick == "btnCpfPhaseTwo") {

            cpfClickPhaseTwo();

        }

        else if (idClick == "btnAddrPhaseTwo") {

            addressClickPhaseTwo();

        }

        else if (idClick == "btnNamePhaseTwo") {

            nameClickPhaseTwo();

        }

        else if (idClick == "btnTelPhaseTwo") {

            telClickPhaseTwo();

        }

    });

    //Botão Voltar
    $('#btnBack').on('click', function () {

        $('#btnPhaseTwo').hide();
        $('#btnDefault').show();
        $('#divPf').removeClass('effect-sadie-2');
        $('div.grid-pf').removeClass('grid-pf-after');
        $('#divPf').addClass('effect-sadie');
        $('#divPj,#divVehicle,#divFtp').delay(1000).fadeIn(500);
        $('#pfCpf,#pfAddr,#pfName,#pfTel').hide();
        $('#btnBack').hide();

    });

});