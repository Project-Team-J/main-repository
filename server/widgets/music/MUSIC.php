<?php

/**
 * Created by PhpStorm.
 * User: user
 * Date: 28/05/2017
 * Time: 15:31
 */
class MUSIC
{
    private $house="https://www.internet-radio.com/player/?mount=http://pulseedm.cdnstream1.com:8124/1373_128.m3u&title=PulseEDM%20Dance%20Music%20Radio&website=www.pulseedm.com";
    private $rock="https://www.internet-radio.com/player/?mount=http://uk5.internet-radio.com:8251/listen.pls&title=Classic%20Rock%20HD%20Plus&website=http://classicrockflorida.com";
    private $hip_hop="https://www.internet-radio.com/player/?mount=http://us1.internet-radio.com:8336/listen.pls&title=LadyLinQRadio&website=http://www.internet-radio.com";

    public function __construct()
    {

    }
    public function run()
    {
        if (isset($_POST['house']))
        {
            echo $this->house;
        }
        if (isset($_POST['rock']))
        {
            echo $this->rock;
        }
        if (isset($_POST['hip']))
        {
            echo $this->hip_hop;
        }
    }
}