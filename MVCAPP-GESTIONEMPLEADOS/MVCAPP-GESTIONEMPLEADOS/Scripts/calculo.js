/*
Script creado por Calcular.cl 
Prohibida su reproducción total o parcial sin el consentimiento
de calcular.cl
*/

function showhidedetails() {

    if (document.getElementById("detalle").style.display == "none") {
        document.getElementById("detalle").style.display = "initial";
        document.getElementById("detalleclick").textContent = "Ocultar bases imponibles y tributable";
    }
    else {
        document.getElementById("detalle").style.display = "none";
        document.getElementById("detalleclick").textContent = "Mostrar bases imponibles y tributable";
    }

}

function reverseNumber(input) {
    return [].map.call(input, function (x) {
        return x;
    }).reverse().join('');
}

function plainNumber(number) {
    return number.split('.').join('');
}

function splitInDots(input) {
    var value = input.value,
        plain = plainNumber(value),
        reversed = reverseNumber(plain),
        reversedWithDots = reversed.match(/.{1,3}/g).join('.'),
        normal = reverseNumber(reversedWithDots);
    //console.log(plain,reversed, reversedWithDots, normal);
    input.value = normal;
}

function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
}

function isNumberKey2(evt) {

    /* version  permite numeros y comas */
    var charCode = (evt.which) ? evt.which : event.keyCode // te entrega la tecla which new browser keycode old ones
    if (charCode > 31 && (charCode < 48 || charCode > 57) && (charCode < 44 || charCode > 44))
        return false;
    return true;

}

function numberWithCommas(x) {
    return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".");
}

function impuestoX(baseTributableX, tipo) {
    var impuesto = 0;
    var i = 0;

    switch (tipo.toLowerCase()) {
        case undefined:
        case "":
        case null:
        case "mensual": divisor = 1; break;
        case "quincenal": divisor = 2; break;
        case "semanal": divisor = (30 / 7); break;
        case "diario": divisor = 30; break;
    }

    // baseTributable * factor - rebaja*utm
    //impuestoUTMdata["0.0"].desde;
    for (i in impuestoUTMdata) {
        if (baseTributableX > (utm * parseFloat(impuestoUTMdata[i].desde)) / divisor && baseTributableX <= (utm * parseFloat(impuestoUTMdata[i].hasta)) / divisor) {
            impuesto = baseTributableX * impuestoUTMdata[i].factor - utm * (impuestoUTMdata[i].rebaja) / divisor;
        }
    }
    return impuesto;
}

function valorHoraExtraX(sueldoX, tipoContrato, horasTrabajadasSemana, horasTrabajadasDiario) {
    // ex. usage: valorHoraExtraX(100000, "Mensual", 45, 0)
    // ex. usage: valorHoraExtraX(100000, "Mensual", 40, 0)
    // ex. usage: valorHoraExtraX(30000, "Diario", 0, 5)
    switch (tipoContrato) {
        case undefined:
        case "":
        case null:
        case "Mensual": horaOrdinaria = sueldoX * (28 / (30 * horasTrabajadasSemana * 4)); break; //mensual
        case "Quincenal": horaOrdinaria = sueldoX / (horasTrabajadasSemana * 2); break; //quincenal
        case "Semanal": horaOrdinaria = sueldoX / horasTrabajadasSemana; break; //semanal
        case "Diario": horaOrdinaria = sueldoX / horasTrabajadasDiario; break; //diario
        case "Variable": break; // IMM/horasTrabajadasSemenal * cantidad horas extras
    }

    valorHoraExtra = horaOrdinaria * 1.5;

    return valorHoraExtra;
}

function resetFonasaIsapre() {
    document.formulario.fonasaisaprecalc.value = "";
};
function resetGratificacion() {
    document.formulario.gratificacion.value = "";
};


function startCalc() {
    interval = setInterval("calc()", 1);
}

function calc() {
    /********************+******************************************/
    /**** SECCION SUELDO BASE EN BASE A DIAS TRABAJADOS EXTRAS ****/
    /*************************************************************/
    if (document.formulario.diasTrabajados.value == '' || document.formulario.diasTrabajados.value == null) {
        diasTrabajados = 0;
    }
    else {
        diasTrabajados = parseInt((document.formulario.diasTrabajados.value).split('.').join("")); // .split('.').join("") quita los puntos
    }

    if (document.formulario.sueldoBase.value == '' || document.formulario.sueldoBase.value == null) {
        sueldoBase = 0;
    }
    else {
        sueldoBase = parseInt((document.formulario.sueldoBase.value).split('.').join("")); // .split('.').join("") quita los puntos

        switch (document.formulario.plazoContrato.value) {
            case undefined:
            case "":
            case null:
            case "Mensual": sueldoBase = parseInt((sueldoBase / 30) * diasTrabajados); break;
            case "Quincenal": sueldoBase = parseInt((sueldoBase / 15) * diasTrabajados); break;
            case "Semanal": sueldoBase = parseInt((sueldoBase / 7) * diasTrabajados); break;
            case "Diario": sueldoBase = parseInt((sueldoBase / 1) * diasTrabajados); break;
        }

        //sueldoBase = parseInt((sueldoBase/30)*diasTrabajados);
        document.formulario.sueldoBaseDias.value = numberWithCommas(Math.round(sueldoBase));
    }

    /********************+***********/
    /**** SECCION GRATIFICACION ****/
    /******************************/
    if (document.formulario.gratificacionSelect.value == "incluir") {
        document.formulario.gratificacion.setAttribute("placeholder", "");
        document.formulario.gratificacion.setAttribute("readonly", "readonly");

        if (grat > (sueldoBase + horasExtra + bono + comisiones) * 0.25) {
            gratificacion = Math.round((sueldoBase + horasExtra + bono + comisiones) * 0.25);
            document.formulario.gratificacion.value = numberWithCommas(Math.round(gratificacion));
        }
        else {
            gratificacion = Math.round(grat);
            document.formulario.gratificacion.value = numberWithCommas(Math.round(gratificacion));
        }
    }
    else if (document.formulario.gratificacionSelect.value == 'manual') {
        document.formulario.gratificacion.setAttribute("placeholder", "ingresar");
        document.formulario.gratificacion.removeAttribute("readonly");

        if (document.formulario.gratificacion.value == '' || document.formulario.gratificacion.value == null) {
            gratificacion = 0;
        }
        else {
            gratificacion = parseInt((document.formulario.gratificacion.value).split('.').join(""));;
        }
    }
    else { // noincluir
        document.formulario.gratificacion.setAttribute("placeholder", "");
        document.formulario.gratificacion.setAttribute("readonly", "readonly");

        gratificacion = 0;
        document.formulario.gratificacion.value = numberWithCommas(Math.round(gratificacion));
    }


    // leer los demas campos antes de total haberes
    if (document.formulario.comisiones.value == '' || document.formulario.comisiones.value == null) { comisiones = 0; } else {
        comisiones = parseInt((document.formulario.comisiones.value).split('.').join(""));
    }
    if (document.formulario.bono.value == '' || document.formulario.bono.value == null) { bono = 0; } else {
        bono = parseInt((document.formulario.bono.value).split('.').join(""));
    }
    if (document.formulario.horasExtra.value == '' || document.formulario.horasExtra.value == null) { horasExtra = 0; } else {
        horasExtra = parseFloat((document.formulario.horasExtra.value).split(',').join(".")); // acepta comas
    }
    if (document.formulario.colacion.value == '' || document.formulario.colacion.value == null) { colacion = 0; } else {
        colacion = parseInt((document.formulario.colacion.value).split('.').join(""));
    }
    if (document.formulario.movilizacion.value == '' || document.formulario.movilizacion.value == null) { movilizacion = 0; } else {
        movilizacion = parseInt((document.formulario.movilizacion.value).split('.').join(""));
    }

    /********************+**********/
    /**** SECCION HORAS EXTRAS ****/
    /*****************************/
    horasExtra = Math.round(horasExtra * valorHoraExtraX((sueldoBase), "Mensual", 45, 0));
    document.formulario.horasextrascalc.value = numberWithCommas(horasExtra);
    //horasExtra = Math.round(horasExtra*(((sueldoBase/30)*28)/180)*1.5);

    /********************************/
    /**** SECCION TOTAL HABERES ****/
    /******************************/
    totalHaberes = 0;
    totalHaberes = totalHaberes + sueldoBase + gratificacion + comisiones + bono + horasExtra + colacion + movilizacion;
    document.formulario.totalHaberes.value = numberWithCommas(totalHaberes);


    /*********************************/
    /**** SECCION BASE IMPONIBLE ****/
    /*******************************/
    baseImponible = totalHaberes - colacion - movilizacion;
    // si es mayor a tope imponible entonces -> tope imponible
    if (baseImponible > (topeImponibleCotizacionesUF * uf)) {
        baseImponible = Math.round(topeImponibleCotizacionesUF * uf);
    }
    else {
        baseImponible = baseImponible;
    }
    document.formulario.baseImponible.value = numberWithCommas(baseImponible);

    /**********************/
    /**** SECCION AFP ****/
    /********************/
    afp = $("#afp").val();
    if (afp) {
        afpcomision = afpFeeData[afp];
        afp = 0.1 + parseFloat(afpcomision);
    }
    else {
        afpcomision = 0;
        afp = 0;
    }

    afpcalc = afp * baseImponible;
    afpcalccomision = afpcomision * baseImponible;
    document.formulario.afpcalc.value = numberWithCommas(Math.round(afpcalc)); //si mayor que tope imponible entonces afp*tope impoible
    document.formulario.comisionafp.value = afpcomision;
    document.formulario.comisionafpcalc.value = numberWithCommas(Math.round(afpcalccomision));

    /*************************/
    /**** SECCION ISAPRE ****/
    /***********************/
    //fonasaisapreselect.onchange = function(){document.formulario.fonasaisaprecalc.value = "";};

    if (document.formulario.fonasaisapreselect.value == "isapre") {

        document.formulario.fonasaisaprecalc.setAttribute("placeholder", "Plan en UF");
        document.formulario.fonasaisaprecalc.removeAttribute("readonly");

        if (document.formulario.fonasaisaprecalc.value == '' || document.formulario.fonasaisaprecalc.value == null) {
            isapre = 0;
        }
        else {

            if (uf * parseFloat((document.formulario.fonasaisaprecalc.value).split(',').join(".")) < 0.07 * baseImponible) {
                isapre = 0.07 * baseImponible;
                document.formulario.isaprecalc.value = numberWithCommas(Math.round(isapre));
            }
            else {
                isapre = uf * parseFloat((document.formulario.fonasaisaprecalc.value).split(',').join("."));
                document.formulario.isaprecalc.value = numberWithCommas(Math.round(isapre));
            }
        }
    }
    else {
        document.formulario.fonasaisaprecalc.setAttribute("placeholder", "");
        document.formulario.fonasaisaprecalc.setAttribute("readonly", "readonly");
        //document.getElementById("fonasaicon").textContent = "lock";
        //document.getElementById("fonasaicon").style.color = "grey";
        isapre = 0.07 * baseImponible;
        document.formulario.fonasaisaprecalc.value = numberWithCommas(Math.round(isapre));
        document.formulario.isaprecalc.value = 0;
    }

    /*************************/
    /**** SECCION SEGURO ****/
    /***********************/
    baseImponibleSeguro = totalHaberes - colacion - movilizacion // si es mayor a tope imponible entonces tope imponible
    if (baseImponibleSeguro > (topeImponibleSeguroUF * uf)) {
        baseImponibleSeguro = Math.round(topeImponibleSeguroUF * uf);
    }
    else {
        baseImponibleSeguro = baseImponibleSeguro;
    }

    document.formulario.baseImponibleSeguro.value = numberWithCommas(baseImponibleSeguro);

    // paga el 0,6% si tiene contrato plazo indefinido (2,4% restante el empleador), cualquier otro el empleador paga el total (3%)
    //if(document.formulario.seguroCheck.checked){ 
    if (document.formulario.plazoContratoSelect.value == "indefinido") {
        seguro = 0.006 * baseImponibleSeguro;
        document.formulario.seguro.value = numberWithCommas(Math.round(seguro));
    }
    else {
        seguro = 0;
        document.formulario.seguro.value = numberWithCommas(Math.round(seguro));
    }

    /*************************/
    /**** SECCION APV.   ****/
    /***********************/
    if (document.formulario.apv.value == '' || document.formulario.apv.value == null) { apv = 0; } else {
        apv = parseInt((document.formulario.apv.value).split('.').join(""));
    }

    /**************************/
    /**** SECCION TRIBUTO ****/
    /************************/
    //si isapre es mayor que 7%* topeImponibleCotizacionUF (5,201 UF), si no isapre
    if (isapre > 0.07 * topeImponibleCotizacionesUF * uf) {
        isapreTributable = 0.07 * topeImponibleCotizacionesUF * uf;
    }
    else {
        isapreTributable = isapre;
    }

    baseTributable = totalHaberes - colacion - movilizacion - afpcalc - seguro - apv - isapreTributable; // parece q no se redondea
    document.formulario.baseTributable.value = numberWithCommas(Math.round(baseTributable));

    impuesto = impuestoX(baseTributable, document.formulario.plazoContrato.value);
    document.formulario.impuesto.value = numberWithCommas(Math.round(impuesto));

    descuentos = afpcalc + isapre + seguro + apv + impuesto;
    document.formulario.descuentos.value = numberWithCommas(Math.round(descuentos));

    sueldoLiquido = totalHaberes - descuentos;
    document.formulario.sueldoLiquido.value = numberWithCommas(Math.round(sueldoLiquido));

    M.updateTextFields();
}

function stopCalc() {
    clearInterval(interval);
    M.updateTextFields();
}

$("form[name=formulario]").click(function () {
    $("#formulario").submit();
});


$(document).ready(function () {

    $('#utm').attr('value', '$' + numberWithCommas(utm.toString().replace(".", ",")));
    $('#uf').attr('value', '$' + numberWithCommas(uf.toString().replace(".", ",")));
    $('#imm').attr('value', '$' + numberWithCommas(imm.toString().replace(".", ",")));

    M.updateTextFields();

});

$("#plazoContratoSelect, #gratificacion, #comisiones, #bono, #horasExtra, #colacion, #movilizacion, #fonasaisaprecalc, #apv").each(function () {
    $(this).focus(function () {
        startCalc();
    });

    $(this).blur(function () {
        stopCalc();
    });

    if ($(this).attr('id') != "plazoContratoSelect" && $(this).attr('id') != "fonasaisaprecalc" && $(this).attr('id') != "horasExtra") {
        $(this).keypress(function () {
            return isNumberKey(event);
        });

        $(this).keyup(function () {
            splitInDots(this);
        });
    }
    if ($(this).attr('id') == "plazoContratoSelect") {
        $(this).change(function () {
            startCalc();
        });
    }
});

$("input, select").each(function () {

    if ($(this).attr('id') == "sueldoBase") {

        $(this).focus(function () {
            startCalc();
        });

        $(this).blur(function () {
            stopCalc();
            gtag('event', 'sueldo base', { 'event_category': 'Form sueldo liquido', 'event_label': formulario.sueldoBase.value });
        });

        $(this).keypress(function () {
            return isNumberKey(event);
        });

        $(this).keyup(function () {
            splitInDots(this);
        });
    }

    if ($(this).attr('id') == "diasTrabajados") {

        $(this).focus(function () {
            startCalc();
        });

        $(this).blur(function () {
            stopCalc();
            gtag('event', 'dias trabajados', { 'event_category': 'Form sueldo liquido', 'event_label': formulario.diasTrabajados.value });
        });
    }

    if ($(this).attr('id') == "gratificacionSelect") {

        $(this).focus(function () {
            startCalc();
        });

        $(this).blur(function () {
            stopCalc();
        });

        $(this).change(function () {
            resetGratificacion();
            startCalc();
        });
    }

    if ($(this).attr('id') == "afp") {

        $(this).focus(function () {
            startCalc();
        });

        $(this).blur(function () {
            stopCalc();
        });

        $(this).change(function () {
            startCalc();
            gtag('event', 'afp', { 'event_category': 'Form sueldo liquido', 'event_label': formulario.afp.value });
        });
    }

    if ($(this).attr('id') == "fonasaisapreselect") {

        $(this).focus(function () {
            startCalc();
        });

        $(this).blur(function () {
            stopCalc();
        });

        $(this).change(function () {
            resetFonasaIsapre();
            startCalc();
            gtag('event', 'fonasa/isapre', { 'event_category': 'Form sueldo liquido', 'event_label': formulario.fonasaisapreselect.value });

        });

    }

});

/*$('a.tooltipx').webuiPopover({width:300, animation:'pop'});*/

