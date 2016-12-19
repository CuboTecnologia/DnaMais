$(document).ready(function () {

    //Veículos
    //Clique em Placa
    $('#btnPlate').on('click', function (e) {

        var idClick = e.target.id;

        //Clicando em Placa
        if (idClick == "btnPlate") {

            vehicleTransitionEffect();

            setTimeout(function () {
                
                $('#vehiclePlate').fadeIn(800);
                $('#txtPlate').focus();

            }, 1000);

        }

    });

    //Botão Voltar
    $('#btnBackVehicle').on('click', function () {

        $('#btnVehiclePhaseTwo').hide();
        $('#btnDefaultVehicle').show();
        $('#divVehicle').removeClass('effect-sadie-2');
        $('div.grid-vehicle').removeClass('grid-vehicle-after');
        $('#divVehicle').addClass('effect-sadie');
        $('#divPf,#divPj').delay(1000).fadeIn(500);
        $('#divFtp').delay(1100).fadeIn(500);
        $('#vehiclePlate').hide();
        $('#btnBackVehicle').hide();

    });

});