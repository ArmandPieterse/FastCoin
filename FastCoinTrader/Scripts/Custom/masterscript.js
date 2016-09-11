//Sales Functionality
$(document).ready(function () {
    //===========================TOTAL EVENTS START==================================
    $("#total").on("focus", function () { $(this).val(removeCurrency(getTotal())); });

    $("#total").on("focusout", function () { $(this).val(addCurrency(getTotal())); });

    $("#total").change(function () {        
        if (getPrice() > 0)
        {                  
            $("#amount").val(addBTC(getTotal() / getPrice()));
        }
        else if (getAmount() > 0)
        {
            $("#price").val(addCurrency(getTotal() / getAmount()));
        }
        setFee();
        checkAll();
    });
    //===========================TOTAL EVENTS END==================================

    //===========================PRICE EVENTS START==================================
    $("#price").on("focus", function () { $(this).val(getPrice()); });
    $("#price").on("focusout", function () { $(this).val(addCurrency(getPrice())); });
    $("#price").change(function () {
        if (getAmount() !== null && $("#amount").val() !== null) {
            var total = getAmount() * getPrice();
            $("#total").val(addCurrency(total));
        }
        setFee();
        checkAll();
    });
    //===========================PRICE EVENTS END==================================

    //===========================AMOUNT EVENTS START==================================
    $("#amount").on("focus", function () { $(this).val(getAmount()); });
    $("#amount").on("focusout", function () { $(this).val(addBTC(getAmount())); });
    $("#amount").change(function () {        
        if (getPrice() !== null && getAmount() !== null)
        {
            var total = getAmount() * getPrice();
            $("#total").val(addCurrency(total));
        }
        setFee();
        checkAll();
    });
    //===========================PRICE EVENTS END==================================

    $(".selling-button").click(function () {
        $('#myModal').modal('show');   
    });
    
    $(".buying-button").click(function () {
        $('#myModal').modal('show');
    });

    if (window.location.href.indexOf('Sales') != -1 || window.location.href.indexOf('Buy') != -1) 
    {
        setInterval(function () {
            if (window.location.href.indexOf('Sales') != -1)
            {
                refreshBuyOffers();
            }
            else if (window.location.href.indexOf('Buy') != -1)
            {
                refreshSalesOffers();
            }
        }, 5000);
    }   
    
});
//===============================SELL && BUY SCREEN FUNCTIONS START====================================

function setFee()
{
    $("#fee").val(addBTC(getAmount() * 0.005));
}

function getTotal()
{
    return removeCurrency($("#total").val());
}

function getAmount()
{
    return removeBTC($("#amount").val());
}

function getPrice()
{
    return removeCurrency($("#price").val());
}

function removeCurrency(value)
{
    return Number(value.replace("R ","")).toFixed(2);
}

function addCurrency(value)
{
    return "R " + Number(value).toFixed(2);
}

function removeBTC(value)
{
    return Number(value.replace("BTC ", "")).toFixed(8);
}

function addBTC(value)
{
    return "BTC " + Number(value).toFixed(8);
}
function isSalesScreen()
{
    return (window.location.href.indexOf("Sales") != -1);
}
function isBuysScreen()
{
    return (window.location.href.indexOf("Buys") != -1);
}
function submitForm()
{
    salesValues =
        {
            amount : getAmount().toString(),
            price : getPrice().toString(),
            total : getTotal().toString(),
        };

    $('#myModal').modal('hide');
    if (isSalesScreen())
        url = '../Sales/CreateSale';
    else if (isBuysScreen())
        url = '../Buys/CreateBuy';

    $.ajax({
        method: 'POST',
        url: url,
        data:  JSON.stringify(salesValues),
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            refreshBuyOffers();
            if (typeof result.message != 'undefined')
            {
                if (result.message.indexOf('success') != -1)
                {
                    showToastr('success', result.message, 5000); 
                }
                else if (result.message.indexOf('Error') != -1)
                {
                    showToastr('error', result.message, 5000); 
                }
            }
                       
        },
        error: function (result) {
            console.log(result);
        }
    });
}

function closeModal()
{
    $('#myModal').modal('hide');
}

function checkAll()
{
    if (getAmount() > 0 && getPrice() > 0 && getTotal() > 0)
    {
        if (window.location.href.indexOf('Sales') != -1)
            $('.selling-button').attr('disabled', false);
        else
            $('.buying-button').attr('disabled', false);

        return true;
    }
    else
    {
        if (window.location.href.indexOf('Sales') != -1)
            $('.selling-button').attr('disabled', true);
        else
            $('.buying-button').attr('disabled', true);

        return false;
    }
}

function refreshBuyOffers()
{
    $.ajax({
        url: '../Sales/_BuyOffers',
        success: function (result) {
            $(".buy-offers-table").html(result);
        },
        error: function (result) {
            console.log(result);
        }
    });    
}

function refreshSalesOffers()
{
    $.ajax({
        url: '../Buys/_SaleOffers',
        success: function (result) {
            $(".sale-offers-table").html(result);
        },
        error: function (result) {
            console.log(result);
        }
    });
}

function sellButtons(number) {
    var row = $('.row' + number);
    var columns = $(row).find('td');
    var BTCtoBuy = columns[1].innerHTML;
    var Price = columns[3].innerHTML;
    var Total = columns[4].innerHTML;

    $("#amount").val(addBTC(BTCtoBuy));
    $("#price").val(Price);
    $("#amount").trigger('change');
    setFee();
    if (checkAll())
    {
        $("#myModal").modal('show');
    }
}

function buyButtons(number)
{
    var row = $('.row' + number);
    var columns = $(row).find('td');
    var BTCtoBuy = columns[1].innerHTML;
    var Price = columns[3].innerHTML;
    var Total = columns[4].innerHTML;

    $("#amount").val(addBTC(BTCtoBuy));
    $("#price").val(Price);
    $("#amount").trigger('change');
    setFee();
    if (checkAll()) {
        $("#myModal").modal('show');
    }
}
//===============================SELL && BUY SCREEN FUNCTIONS END====================================

//===============================GENERAL FUNCTIONS START====================================
function showToastr(type,message,time)
{
    toastr.options = {
        "closeButton": true,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-top-center",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": time,
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    };
    toastr[type](message);
}

//===============================GENERAL FUNCTIONS END====================================
