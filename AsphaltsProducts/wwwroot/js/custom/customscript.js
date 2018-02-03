 jQuery (document).ready(function () {
    $.ajaxSetup({ cache: false });
});


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

//Method used to calculate my experience :)
function CalculateMyExperience() {
    if ($('.years-of-exp').length > 0) {
        $('.years-of-exp').text(getAge(new Date(2015, 1, 2), new Date()));
    }
}

//Method used to hide page loading icon
function HideLoadingIcon() {
    $('.loader').hide();
}

//Method used to show page loading icon
function ShowLoadingIcon() {
    $('.loader').show();
}

//Function used to populate few products in homepage
function LoadFewProducts() {
       
    jQuery.getJSON("https://res.cloudinary.com/harishscdn/raw/upload/v1517035755/ecom-app/products.json", function (homePageProducts) {
        var products = homePageProducts.products;
        if (jQuery('#itemTemplate').length > 0) {
            
            $.each(products, function (index, value) {
                var html = jQuery('#itemTemplate').html();

                html = html
                    .replace('##PRODUCTNAME##', value.productName)
                    .replace('##PRODUCTNAME##', value.productName)
                    .replace('##PRODUCTRATING##', value.productRating)
                    .replace('##ACTUALPRICE##', value.retailPrice)
                    .replace('##OFFERPRICE##', value.discountedPrice)
                    .replace('##CAROUSELNAME##', value.id)
                    .replace('##CAROUSELNAME##', value.id)
                    .replace('##CAROUSELNAME##', value.id)
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

//Global variable used to show notification message 
var duplicateItem = false;
//Function will add items to cart
function AddToCart(item, e) {    
    if (Storage != "undefined") { 
        var selectedProduct = {
            'ProductName': $(item).parents('.item-container').find('.panel-heading').html(),
            'ProductId': $(item).parents('.item-container').find('.carousel').attr('id')
        }
        AddedCartItems(selectedProduct);   
        var productId = $(item).parents('.item-container').find('.carousel').attr('id')

        if (localStorage.getItem("cart-item-" + productId)) {
            //alert('this product is already in your cart');            
            $('.notification-message').text('this product is removed from your cart')
            $('.alert-success').stop().slideDown().delay(3000).slideUp();
            $('[data-productid=' + productId + ']').removeClass('added');
            $('[data-productid=' + productId + ']').find('.cart-text').text('add to cart');
            localStorage.removeItem("cart-item-" + productId)
            duplicateItem = true;
            //StopPrpagation();
            return false;
        } else {
            duplicateItem = false;
            localStorage.setItem("cart-item-" + productId, productId);    
            $('[data-productid=' + productId + ']').addClass('added');
            $('[data-productid=' + productId + ']').find('.cart-text').text('In cart');
        }
        
        var noOfCartItems = 0;
        noOfCartItems = CartItemsCount();
                
        if (noOfCartItems > 0) {
            $('.cart-items-count').html(noOfCartItems);
            $('.cart-items-count').show();
        };
    } 
}

//Function used to add items to cart
function CartItemsCount() {
    var noOfCartItems = 0;
    Object.keys(window.localStorage).filter(function (keyname) {
        if (keyname.toString().indexOf('cart-item') > -1); {
            noOfCartItems += 1;
        }
    });
    return noOfCartItems;
}

//Function used to count the items added to cart by user and display it
function ShowNumberOfCartItemsAdded() {
    var itemsCount = CartItemsCount();
    if (itemsCount > 0) {
        $('.cart-items-count').html(itemsCount);
        $('.cart-items-count').show();
    }

}

//Function used to stop furter propagaion 
function StopPrpagation(e) {
    if (!e)
        e = window.event;

    //IE9 & Other Browsers
    if (e.stopPropagation) {
        e.stopPropagation();
    }
    //IE8 and Lower
    else {
        e.cancelBubble = true;
    }
}


function GetCartItems() {
    $.getJSON('cart/GetCartItems').success(function (itemsIncart) {

        
        $.each(itemsIncart.cartItems, function (i, v) {
        
            console.log(v.productId);
            $('[data-productid=' + v.productId + ']').addClass('added');
            $('[data-productid=' + v.productId + ']').find('.cart-text').text('In cart');
        })
    })
        .error(function (err) { alert('get json dint worked'); })
}


window.onload = ShowNumberOfCartItemsAdded(), CalculateMyExperience(), LoadFewProducts(), GetCartItems();
window.onloadstart = ShowLoadingIcon();

//Track items added to cart by client 
function AddedCartItems(product) {
    $.ajax({
        url: 'cart/ToggleCartSelection',
        data: product,
        success: function (res) {
            console.log( res);
        },
        error: function (err) {
            console.log(err);
        }
    })
}


jQuery(document).ready(function () {
    jQuery(window).bind('beforeunload', function () {
        ShowLoadingIcon();
    });
    jQuery("body").on('click', '*[data-message]', function (target) {
        if (!duplicateItem) {
            $('.notification-message').text('product is added to your cart')
            $('.alert-success').stop().slideDown().delay(3000).slideUp();
        }
    });
    $('#contact_form').bootstrapValidator({
        // To use feedback icons, ensure that you use Bootstrap v3.1.0 or later
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            first_name: {
                validators: {
                    stringLength: {
                        min: 2,
                    },
                    notEmpty: {
                        message: 'Please supply your first name'
                    }
                }
            },
            last_name: {
                validators: {
                    //stringLength: {
                    //    min: 2,
                    //},
                    //notEmpty: {
                    //    message: 'Please supply your last name'
                    //}
                }
            },
            email: {
                validators: {
                    //notEmpty: {
                    //    message: 'Please supply your email address'
                    //},
                    emailAddress: {
                        message: 'Please supply a valid email address'
                    }
                }
            },
            phone: {
                validators: {
                    //notEmpty: {
                    //    message: 'Please supply your phone number'
                    //},
                    phone: {
                        country: 'US',
                        message: 'Please supply a vaild phone number with area code'
                    }
                }
            },
            address: {
                validators: {
                    stringLength: {
                        min: 8,
                    },
                    //notEmpty: {
                    //    message: 'Please supply your street address'
                    //}
                }
            },
            city: {
                validators: {
                    stringLength: {
                        min: 4,
                    }
                    //,notEmpty: {
                    //    message: 'Please supply your city'
                    //}
                }
            },
            state: {
                validators: {
                    //notEmpty: {
                    //    message: 'Please provide your state'
                    //}
                    stringLength: {
                        min:2,
                    }
                }
            },
            zip: {
                validators: {
                    //notEmpty: {
                    //    message: 'Please supply your zip code'
                    //},
                    zipCode: {
                        country: 'US',
                        message: 'Please supply a vaild zip code'
                    }
                }
            },
            comment: {
                validators: {
                    stringLength: {
                        min: 10,
                        max: 200,
                        message: 'Please enter at least 10 characters and no more than 200'
                    },
                    notEmpty: {
                        message: 'Please supply a description of your project'
                    }
                }
            }
        }
    })
        .on('success.form.bv', function (e) {
            $('#success_message').slideDown({ opacity: "show" }, "slow") // Do something ...
            $('#contact_form').data('bootstrapValidator').resetForm();

            // Prevent form submission
            e.preventDefault();

            // Get the form instance
            var $form = $(e.target);

            // Get the BootstrapValidator instance
            var bv = $form.data('bootstrapValidator');

            // Use Ajax to submit form data
            $.post($form.attr('action'), $form.serialize(), function (result) {
                console.log(result);
            }, 'json');
        });

});