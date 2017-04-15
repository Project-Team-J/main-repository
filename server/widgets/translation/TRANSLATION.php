<?php


/**
 * Created by PhpStorm.
 * User: תומר אוליאל
 * Date: 15/04/2017
 * Time: 16:43
 */
class TRANSLATION
{
    private $app;
    private $data;
    private $lang;
    private $text;


    function __construct(string $text, string $lang)
    {
        $this->app = new App();
        $this->text = $text;
        $this->lang = $lang;
//        $guzzleClient = new \GuzzleHttp\Client(array( 'curl' => array( CURLOPT_SSL_VERIFYPEER => false, ), ));
//        $this->app->gClient->setHttpClient($guzzleClient);
        $this->app->setg_Client('https://translate.yandex.net/');
        $this->data = $this->app->getJsonData('api/v1.5/tr.json/translate?key=trnsl.1.1.20170415T133650Z.f5a14b39838bb463.8db86d2856c1bc91ca80d8da8eb0c148e61c70f5&text='.$this->text.'&lang='.$this->lang.'');
    }

    /**
     * @return mixed
     */
    public function getLang()
    {
        return $this->lang;
    }

    /**
     * @param mixed $lang
     */
    public function setLang($lang)
    {
        $this->lang = $lang;
    }

    /**
     * @return mixed
     */
    public function getText()
    {
        return $this->text;
    }

    /**
     * @param mixed $text
     */
    public function setText($text)
    {
        $this->text = $text;
    }

    function getData()
    {
        return $this->data;
    }

    function run(){
            echo $this->getData();
    }

}
