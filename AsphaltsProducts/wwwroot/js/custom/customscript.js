function getAge(date_1, date_2) {

    //convert to UTC
    var date2_UTC = new Date(Date.UTC(date_2.getUTCFullYear(), date_2.getUTCMonth(), date_2.getUTCDate()));
    var date1_UTC = new Date(Date.UTC(date_1.getUTCFullYear(), date_1.getUTCMonth(), date_1.getUTCDate()));


    var yAppendix, mAppendix, dAppendix;


    //--------------------------------------------------------------
    var days = date2_UTC.getDate() - date1_UTC.getDate();
    if (days < 0) {

        date2_UTC.setMonth(date2_UTC.getMonth() - 1);
        days += DaysInMonth(date2_UTC);
    }
    //--------------------------------------------------------------
    var months = date2_UTC.getMonth() - date1_UTC.getMonth();
    if (months < 0) {
        date2_UTC.setFullYear(date2_UTC.getFullYear() - 1);
        months += 12;
    }
    //--------------------------------------------------------------
    var years = date2_UTC.getFullYear() - date1_UTC.getFullYear();




    if (years > 1) yAppendix = " years";
    else yAppendix = " year";
    if (months > 1) mAppendix = " months";
    else mAppendix = " month";
    if (days > 1) dAppendix = " days";
    else dAppendix = " day";


    return years + yAppendix + ", " + months + mAppendix + ", and " + days + dAppendix + ".";
}


function DaysInMonth(date2_UTC) {
    var monthStart = new Date(date2_UTC.getFullYear(), date2_UTC.getMonth(), 1);
    var monthEnd = new Date(date2_UTC.getFullYear(), date2_UTC.getMonth() + 1, 1);
    var monthLength = (monthEnd - monthStart) / (1000 * 60 * 60 * 24);
    return monthLength;
}

function CalculateMyExperience() {
    if ($('.years-of-exp').length > 0) {
        $('.years-of-exp').text(getAge(new Date(2015, 1, 2), new Date()));
    }
}

function HideLoadingIcon() {
    $('.loader').hide();
}
function ShowLoadingIcon() {
    $('.loader').show();
}

function LoadFewProducts() {

    jQuery.getJSON("/json/products.json?ff=jk1120", function (homePageProducts) {
        var products = homePageProducts.products;
        if (jQuery('#itemTemplate').length > 0) {
            
            $.each(products, function (index, value) {
                var html = jQuery('#itemTemplate').html();

                html = html
                    .replace('##PRODUCTNAME##', value.productName)
                    .replace('##PRODUCTRATING##', value.productRating)
                    .replace('##ACTUALPRICE##', value.retailPrice)
                    .replace('##OFFERPRICE##', value.discountedPrice)
                    .replace('##CAROUSELNAME##', value.id);
                
                //populate slider indicators 
                var indicator = jQuery(html).find('ol.carousel-indicators');
                var carouselInner = jQuery(html).find('.carousel-inner');
                var images = JSON.parse(homePageProducts.products[index].productImage);
                for (i = 0; i < images.length; i++) {
                    jQuery(indicator).append(jQuery('<li data-target="#' + value.id + '" data-slide-to="' + i + '" ></li>'))
                    jQuery(carouselInner).append(jQuery('<div class="item"><img class="img-responsive img-rounded" src= "' + images[i] + '" /></div >'));
                                        
                }

                jQuery(indicator).find('li').first().addClass('active');
                jQuery(carouselInner).find('div.item').first().addClass('active');

                html = html.replace('##INDICATORS##', $(indicator).html().replace('##INDICATORS##', ''))
                    .replace('##CAROUSELIMAGES##', $(carouselInner).html().replace('##CAROUSELIMAGES##', ''));
                                
                jQuery('#products').append(html)
            });
        }
        
    });
}

$(document).ready(function () {
    jQuery(window).bind('beforeunload', function () {
        ShowLoadingIcon();
    });
    
});

window.onload = CalculateMyExperience(), LoadFewProducts();
window.onloadstart = ShowLoadingIcon();