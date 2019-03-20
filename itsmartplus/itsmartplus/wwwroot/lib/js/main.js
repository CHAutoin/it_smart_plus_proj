function a(value){
    console.log(value);
}
window.onload = ()=> {
    let x = document.body.getElementsByTagName("div")[4];
    x.style.cursor = "default";
}
//more_vert
document.addEventListener('DOMContentLoaded', function() {
    var elems = document.querySelectorAll('.dropdown-trigger');
    var instances = M.Dropdown.init(elems);
});

//collapsible
document.addEventListener('DOMContentLoaded', function() {
    var elems = document.querySelectorAll('.collapsible');
    var instances = M.Collapsible.init(elems);
});


//Carousel
let next_ = document.getElementById("next_");
let prev_ = document.getElementById("prev_");

document.addEventListener('DOMContentLoaded', function() {
    var elems = document.querySelectorAll('.slider');
    let instance = M.Slider.init(elems,{
        fullWidth: true,
        indicators : false
    }); 
});

function sled_car(get_ID){
    let slid = document.getElementById("caru");
    let inst = M.Carousel.getInstance(slid);
    switch (get_ID) {
        case ("next_") : 
            inst.next();
        break;

        case ("prev_") :
            inst.prev();
        break;

            default :
                console.warn("No slide");
                break;
    }
}

//On Started
let Cur_url = window.location.pathname;

//Url 
function send_url(urlx){
    window.location.href = `${urlx}`
}

let typex = "";
//let typex = `.cshtml`
function link(getId){
    switch (getId) {
        case ("brand_printers"):
            send_url(`./listprinters${typex}`);
            break;

        case ("list_pm"):
            send_url('/pm/pmindex');
            //send_url(`./pmindex{typex}`)
            //console.log("link : 0.0.0.0/PM");
            break;

        case ("BM"):
            console.log(`link : 0.0.0.0/BM${typex}`);
            break;

        case ("MTTR"):
            console.log(`link : 0.0.0.0/MTTR${typex}`);
            break;

        case ("MTBF"):
            console.log(`link : 0.0.0.0/MTBF${typex}`);
            break;

        case ("MTBF"):
            console.log(`link : 0.0.0.0/MTBF${typex}`);
        break;

        case ("check"):
            console.log(`check${typex}`);
            break;

        case ("PM"): 
            send_url(`./pmindex${typex}`);
            //console.log(`list_pm.html`);
            break;

        case ("PM_p"):
            send_url(`../list_pm${typex}`);
            break;

        case ("Home"):
            send_url(`main${typex}`);
            //console.log("Home");
            break;

        case ("Home_p"):
            send_url(`../main${typex}`);
            break;

        case ("list_printers"):
            send_url(`listprinters${typex}`);
            //console.log(`list_printers.html`);
            break;

        case ("epson"):
            send_url(`./pages/epson${typex}`);
            break;

        case ("tb_pm"):
            send_url(`list_printers${typex}`);
            break;

        /*
        case ("tb_check"):
            send_url(`./tb_check${typex}`);
            break;
        */
        case ("btn_search"):
            send_url(`./this_detail${typex}`);
            break;
        
        case ("PM_this"): 
            send_url(`./checked_pm${typex}`);
            break;

        default :
        console.error("Not Found : 404");
    }
}
