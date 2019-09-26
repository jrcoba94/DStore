<%@ Page Title="" Language="C#" MasterPageFile="~/src/VentasAllMusic.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="DisqueraVentas.GUI.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="carousel carousel-slider center" data-indicators="true">
        <h3>U-Sound</h3>
        <img src="../src/Img/LogoAM.ico" />
        <a class="carousel-item" href="#one!">
            <img src="../src/Img/Video-Slide.png" /></a>
        <a class="carousel-item" href="#two!">
            <img src="../src/Img/Main-Slide1.png" /></a>
        <a class="carousel-item" href="#three!">
            <img src="../src/Img/Event-Slider-One.png" /></a>
        <a class="carousel-item" href="#four!">
            <img src="../src/Img/Video-Slide.png" /></a>
    </div>
    <div class="divider"></div>
    <div class="section">
        <div id="about" class="whitebg scrollspy">
            <div class="row container">
                <div id="accordion" class="section scrollspy">
                    <div class="row">
                        <!-- Left Section -->
                        <div class="col l6 s12">
                            <div class="clearfix">
                                <div class="col s12 l6 marbot30">
                                    <div class="material-placeholder">
                                        <img data-wow-delay="0.1s" class="responsive-img materialboxed span3 wow flipInY z-depth-4 intialized animated" data-caption="A picture of some deer and tons of trees" src="../src/Img/35-250x250.jpg" alt=" " style="visibility: visible; animation-delay: 0.1s; animation-name: flipInY;"/>
                                    </div>
                                    <br />
                                    <div class="material-placeholder">
                                        <img data-wow-delay="0.1s" class="responsive-img materialboxed span3 wow flipInY z-depth-4 intialized animated" data-caption="A picture of some deer and tons of trees" src="../src/Img/41-250x250.jpg" alt=" " style="visibility: visible; animation-delay: 0.1s; animation-name: flipInY;"/>
                                    </div>
                                </div>
                                <br /><br />
                                <div class="col s12 l6 marbot30">
                                    <br />
                                    <div class="material-placeholder">
                                        <img data-wow-delay="0.1s" class="responsive-img materialboxed span3 wow flipInY z-depth-4 intialized animated" data-caption="A picture of some deer and tons of trees" src="../src/Img/2-250x250.jpg" alt=" " style="visibility: visible; animation-delay: 0.1s; animation-name: flipInY;"/>
                                    </div>
                                    <br />
                                    <div class="material-placeholder">
                                        <img data-wow-delay="0.1s" class="responsive-img materialboxed span3 wow flipInY z-depth-4 intialized animated" data-caption="A picture of some deer and tons of trees" src="../src/Img/13-250x250.jpg" alt=" " style="visibility: visible; animation-delay: 0.1s; animation-name: flipInY;"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- Left Section -->

                        <!-- Right Section -->
                        <div class="col l6 s12">
                            <div class="center">
                                <h3 class="animated" data-wow-delay="300ms" style="visibility: visible; animation-delay: 300ms; animation-name:fadeInLeft;">Tu musica en U-Sound</h3>
                                <div class="hr-line"><i class="mdi-action-star-rate"></i></div>
                                <div class="tag padding-12-per">
                                    Consigue tu musica favorita en una sola página.
                                    Disfruta de la musica de artistas internacionales.
                                </div>
                            </div>
                        </div>
                        <!-- Right Section -->
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script>
        $('.carousel.carousel-slider').carousel({
            duration: 200,
            fullWidth: true
        });
    </script>
</asp:Content>
