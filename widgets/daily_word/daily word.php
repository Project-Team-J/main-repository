<?php
/**
 * Created by PhpStorm.
 * User: user
 * Date: 29/03/2017
 * Time: 15:44
 */
class DailyWord
{
    public $word;
    public $image;

    function __construct()
    {
        $word = array(
            'word'=>$this->page_word('https://www.merriam-webster.com/word-of-the-day'));
        die(json_encode($word));
    }
    function page_word($url)
    {

        $page = @file_get_contents($url);

        if (!$page) return null;

        $matches = array();

        if (preg_match('/<h1>(.*?)<\/h1>/', $page, $matches)) {
            return $matches[1];
        } else {
            return null;
        }
        #create json

    }
    function get_word()
    {
        return self::$word;
    }
    function get_image()
    {
        return self::$image;
    }
}
$day_word=new DailyWord();
echo $day_word->get_word();