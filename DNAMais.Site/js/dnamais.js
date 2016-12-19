function changeDetected() {
    if (!changes) {
        $('#divChanges').show();
        changes = true;
    }
}

function changeAlert(location) {
    var ret = false;
    if (!changes) {
        ret = true;
    }
    else {
        ret = confirm('Alterações foram realizadas. Ao abandonar o cadastro, tais alterações serão perdidas. Confirma?');
    }

    if (ret) {
        window.location = location;
    }
}

function onlyNumbers(evento) {

    var tecla = new Number();

    if (window.event) {
        tecla = evento.keyCode;
    }
    else if (evento.which) {
        tecla = evento.which;
    }
    else {
        return true;
    }
    if (((tecla < 48) || (tecla > 57)) && (tecla != 8)) {
        return false;
    }
}

function maskDate(campo) {

    var valor = campo.value;

    if (event.keyCode == 8) {
        return;
    }

    if (valor.length == 2 || valor.length == 5) {
        valor = valor + '/';
    }

    campo.value = valor;
}

function maskHour(campo) {

    var valor = campo.value;

    if (event.keyCode == 8) {
        return;
    }

    if (valor.length == 2) {
        valor = valor + ':';
    }

    if (valor.substr(0, 2) > 23) {
        campo.value = '';
    }
    else if (valor.substr(3, 2) > 60) {
        campo.value = '';
    }
    else {
        campo.value = valor;
    }
}

function maskHourExtension(campo) {

    var valor = campo.value;

    if (event.keyCode == 8) {
        return;
    }

    if (valor.length == 3) {
        valor = valor + ':';
    }

    if (valor.substr(3, 2) > 60) {
        campo.value = '';
    }
    else {
        campo.value = valor;
    }
}

function maksCEP(campo) {

    var valor = campo.value;

    if (event.keyCode == 8) {
        return;
    }

    if (valor.length == 5) {
        valor = valor + '.';
    }

    campo.value = valor;
}

function maskCPF(campo, evento) {

    var valor = campo.value;

    if (window.event) {
        tecla = evento.keyCode;
    }
    else if (evento.which) {
        tecla = evento.which;
    }
    else {
        return true;
    }

    if (tecla == 8) {
        return;
    }

    if (valor.length == 3 || valor.length == 7) {
        valor = valor + '.';
    }

    if (valor.length == 11) {
        valor = valor + '-';
    }

    campo.value = valor;
}

function maskCNPJ(campo, evento) {

    var valor = campo.value;

    if (window.event) {
        tecla = evento.keyCode;
    }
    else if (evento.which) {
        tecla = evento.which;
    }
    else {
        return true;
    }

    if (tecla == 8) {
        return;
    }

    if (valor.length == 2 || valor.length == 6) {
        valor = valor + '.';
    }

    if (valor.length == 10) {
        valor = valor + '/';
    }

    if (valor.length == 15) {
        valor = valor + '-';
    }

    campo.value = valor;
}

function maskValue(campo) {

    if (event.keyCode == 9) {
        return;
    }

    valor = campo.value;
    valor = valor.replace(/\D/g, "") // permite digitar apenas numero 
    valor = valor.replace(/(\d{1})(\d{14})$/, "$1.$2") // coloca ponto antes dos ultimos digitos 
    valor = valor.replace(/(\d{1})(\d{11})$/, "$1.$2") // coloca ponto antes dos ultimos 11 digitos 
    valor = valor.replace(/(\d{1})(\d{8})$/, "$1.$2") // coloca ponto antes dos ultimos 8 digitos 
    valor = valor.replace(/(\d{1})(\d{5})$/, "$1.$2") // coloca ponto antes dos ultimos 5 digitos 
    valor = valor.replace(/(\d{1})(\d{1,2})$/, "$1,$2") // coloca virgula antes dos ultimos 2 digitos 
    campo.value = valor;
}

function maskPhone(campo) {

    var valor = campo.value;

    if (valor.length == 4) {
        if (event.keyCode == 8) {
            return;
        }

        valor = valor + '.';
    }

    if (valor.length == 10) {
        valor = valor.replace('.', '');
        valor = valor.substring(0, 5) + '.' + valor.substring(5, 9)
    }

    if (valor.length == 9) {
        valor = valor.replace('.', '');
        valor = valor.substring(0, 4) + '.' + valor.substring(4, 8)
    }

    campo.value = valor;
}
