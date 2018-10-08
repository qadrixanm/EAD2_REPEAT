package com.example.kadri.ead2repeat;

import android.content.Context;
import android.os.AsyncTask;
import android.util.Log;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.Reader;
import java.net.URL;
import java.nio.charset.Charset;
import java.util.HashMap;
import java.util.Map;

public class MyApplication extends AsyncTask<String, Void, Map>
{
    String TAG = getClass().getSimpleName();

    @Override
    protected Map doInBackground(String... strings) {
        Map error=new HashMap();
        Log.d(TAG + " DoINBackGround","On doInBackground...");
        Log.d(TAG,strings[0]);
        String myURL=strings[0];
        try{
            return getData(myURL);
        }catch (IOException e){
            Log.d("Error","City Error");
            e.printStackTrace();
            error.put("Error","An error has occurred.");
        } catch (JSONException e) {
            e.printStackTrace();
        }
        return error;
    }


    private Map getData(String myURL) throws IOException, JSONException {
        JSONObject json = readJsonFromUrl(myURL);
        try {

            Map Data = new HashMap();
            String CityName = json.getString("CityName");
            String ID = json.getString("ID");
            String MaxTemp = json.getString("MaxTemp");
            String MinTemp = json.getString("MinTemp");
            String NextDayWeather = json.getString("NextDayWeather");
            String WeatherCondition = json.getString("WeatherCondition");
            String WeatherDate = json.getString("WeatherDate");
            String WindDirection = json.getString("WindDirection");
            String WindSpeed = json.getString("WindSpeed");
            Data.put("CityName",CityName);
            Data.put("ID",ID);
            Data.put("MaxTemp",MaxTemp);
            Data.put("MinTemp",MinTemp);
            Data.put("NextDayWeather",NextDayWeather);
            Data.put("WeatherCondition",WeatherCondition);
            Data.put("WeatherDate",WeatherDate);
            Data.put("WindDirection",WindDirection);
            Data.put("WindSpeed",WindSpeed);

            Log.e("Success %s", "Data Paresed");


            return Data;
        } catch (JSONException e) {

            e.printStackTrace();
        }
        return null;
    }


    public JSONObject readJsonFromUrl(String url) throws IOException, JSONException {
        InputStream is = new URL(url).openStream();
        try {
            BufferedReader rd = new BufferedReader(new InputStreamReader(is, Charset.forName("UTF-8")));
            String jsonText = readAll(rd);
            JSONObject json = new JSONObject(jsonText);
            return json;
        } finally {
            is.close();
        }
    }


    private String readAll(Reader rd) throws IOException {
        StringBuilder sb = new StringBuilder();
        int cp;
        while ((cp = rd.read()) != -1) {
            sb.append((char) cp);
        }
        return sb.toString();
    }

}

