$(document).ready(function () {

    //Ftp
    //Clique em Test
    $('#btnTest').on('click', function (e) {

        var idClick = e.target.id;
        
        //Clicando em Placa
        if (idClick == "btnTest") {

            ftpTransitionEffect();

            setTimeout(function () {
                
                $('#ftpTest').fadeIn(800);
                $('#txtTest').focus();

            }, 1000);

        }

    });

    //Botão Voltar
    $('#btnBackFtp').on('click', function () {

        $('#btnFtpPhaseTwo').hide();
        $('#btnDefaultFtp').show();
        $('#divFtp').removeClass('effect-sadie-2');
        $('div.grid-ftp').removeClass('grid-ftp-after');
        $('#divFtp').addClass('effect-sadie');
        $('#divPf,#divPj').delay(1000).fadeIn(500);
        $('#divVehicle').delay(1100).fadeIn(500);
        $('#ftpTest').hide();
        $('#btnBackFtp').hide();

    });

});