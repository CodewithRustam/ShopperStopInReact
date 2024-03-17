let Footer = () => {
    return (
        <>
            <footer className="bg-dark" style={{
                color: '#ffffff', padding: '40px 0', fontFamily: 'Arial, sans- serif',
            fontWeight: 'bold' } }>
                <div className="container">
                    <div className="row">
                        <div className="col-md-3">
                            <h5 className="mb-3" style={{ fontWeight: 'bold' }}>Get to Know Us</h5>
                            <ul className="list-unstyled">
                                <li><a href="https://www.aboutamazon.in/?utm_source=gateway&amputm_medium=footer" className="text-decoration-none text-white">About Us</a></li>
                                <li><a href="https://amazon.jobs" className="text-white">Careers</a></li>
                                <li><a href="https://press.aboutamazon.in/?utm_source=gateway&amputm_medium=footer" className="text-white">Press Releases</a></li>
                                <li><a href="https://www.amazon.science" className="text-white">ShopperStop Science</a></li>
                            </ul>
                        </div>
                        <div className="col-md-3">
                            <h5 className="mb-3" style={{ fontWeight: 'bold' }}>Connect with Us</h5>
                            <ul className="list-unstyled">
                                <li><a href="https://www.amazon.in/gp/redirect.html/ref=footer_fb?location=http://www.facebook.com/AmazonIN&amp;token=2075D5EAC7BB214089728E2183FD391706D41E94&amp;6" className="text-white">Facebook</a></li>
                                <li><a href="https://www.amazon.in/gp/redirect.html/ref=footer_twitter?location=http://twitter.com/AmazonIN&amp;token=A309DFBFCB1E37A808FF531934855DC817F130B6&amp;6" className="text-white">Twitter</a></li>
                                <li><a href="https://www.amazon.in/gp/redirect.html?location=https://www.instagram.com/amazondotin&amp;token=264882C912E9D005CB1D9B61F12E125D5DF9BFC7&amp;source=standards" className="text-white">Instagram</a></li>
                            </ul>
                        </div>
                        <div className="col-md-3">
                            <h5 className="mb-3" style={{ fontWeight: 'bold' }}>Make Money with Us</h5>
                            <ul className="list-unstyled">
                                <li><a href="/b/?node=2838698031&amp;ld=AZINSOANavDesktopFooter_C&amp;ref_=nav_footer_sell_C" className="text-white">Sell on ShopperStop</a></li>
                                <li><a href="https://accelerator.amazon.in/?ref_=map_1_b2b_GW_FT" className="text-white">Sell under ShopperStop Accelerator</a></li>
                                <li><a href="https://brandservices.amazon.in/?ref=AOINABRLGNRFOOT&amp;ld=AOINABRLGNRFOOT" className="text-white">Protect and Build Your Brand</a></li>
                                <li><a href="https://sell.amazon.in/grow-your-business/amazon-global-selling.html?ld=AZIN_Footer_V1&amp;ref=AZIN_Footer_V1" className="text-white">ShopperStop Global Selling</a></li>
                                <li><a href="https://affiliate-program.amazon.in/?utm_campaign=assocshowcase&amp;utm_medium=footer&amp;utm_source=GW&amp;ref_=footer_assoc" className="text-white">Become an Affiliate</a></li>
                            </ul>
                        </div>
                        <div className="col-md-3">
                            <h5 className="mb-3" style={{ fontWeight: 'bold' }}>Let Us Help You</h5>
                            <ul className="list-unstyled">
                                <li><a href="/gp/help/customer/display.html?nodeId=GDFU3JS5AL6SYHRD&amp;ref_=footer_covid" className="text-white">COVID-19 and ShopperStop</a></li>
                                <li><a href="/gp/css/homepage.html?ref_=footer_ya" className="text-white">Your Account</a></li>
                                <li><a href="/gp/css/returns/homepage.html?ref_=footer_hy_f_4" className="text-white">Returns Centre</a></li>
                                <li><a href="/gp/help/customer/display.html?nodeId=201083470&amp;ref_=footer_swc" className="text-white">100% Purchase Protection</a></li>
                                <li><a href="/gp/browse.html?node=6967393031&amp;ref_=footer_mobapp" className="text-white">ShopperStop App Download</a></li>
                                <li><a href="/gp/help/customer/display.html?nodeId=200507590&amp;ref_=footer_gw_m_b_he" className="text-white">Help</a></li>
                            </ul>
                        </div>
                    </div>


                    {/*<!-- Copyright section -->*/}
                    <div className="row mt-4">
                        <div className="col-md-12">
                            <ul className="list-unstyled">
                                <li><a href="/gp/help/customer/display.html?nodeId=200545940&amp;ref_=footer_cou" className="text-white">Conditions of Use &amp; Sale</a></li>
                                <li><a href="/gp/help/customer/display.html?nodeId=200534380&amp;ref_=footer_privacy" className="text-white">Privacy Notice</a></li>
                                <li><a href="/gp/help/customer/display.html?nodeId=202075050&amp;ref_=footer_iba" className="text-white">Interest-Based Ads</a></li>
                            </ul>
                            <p className="mb-0 text-muted">© 1996-2023, ShopperStop.com, Inc. or its affiliates</p>
                        </div>
                    </div>
                </div>
            </footer>

        </>
    )
}
export default Footer;
