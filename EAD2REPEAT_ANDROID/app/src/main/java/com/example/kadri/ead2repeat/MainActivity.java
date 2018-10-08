package com.example.kadri.ead2repeat;

import android.app.ActionBar;
import android.app.Activity;
import android.content.Context;
import android.content.DialogInterface;
import android.content.SharedPreferences;
import android.content.res.Configuration;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.View.OnClickListener;
import android.view.inputmethod.EditorInfo;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;
import java.util.concurrent.ExecutionException;
//import com.example.kadri.ead2repeat.MyContextWrapper;

public class MainActivity extends AppCompatActivity {

    Map Data=new HashMap();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        loadLocale();
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        android.support.v7.app.ActionBar actionBar = getSupportActionBar();
        actionBar.setTitle(getResources().getString(R.string.app_name));
        Button changeLang = findViewById(R.id.changeMyLang);
        changeLang.setOnClickListener(new View.OnClickListener(){
            @Override
            public void onClick(View view){
                //show Alert dialog to display list of languages
                showChangeLanguageDialog();
            }
        });
        final Button getData=(Button)findViewById(R.id.getButton);



        getData.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View v) {
                EditText cityText=(EditText)findViewById(R.id.city_name);
                //TextView textView=(TextView)findViewById(R.id.textView);
                TextView cityTxt=(TextView)findViewById(R.id.cityTxt);
                TextView idText=(TextView)findViewById(R.id.idText);
                TextView maxText=(TextView)findViewById(R.id.maxText);
                TextView minText=(TextView)findViewById(R.id.minText);
                TextView ndwText=(TextView)findViewById(R.id.ndwText);
                TextView wcText=(TextView)findViewById(R.id.wcText);
                TextView wdText=(TextView)findViewById(R.id.wdText);
                TextView windDText=(TextView)findViewById(R.id.windDText);
                TextView windSText=(TextView)findViewById(R.id.windSText);
                String baseURL="https://ead2repeat.azurewebsites.net/api/Weather?city=";
                String city=cityText.getText().toString();
                cityText.onEditorAction(EditorInfo.IME_ACTION_DONE);
                if(city==null || city.isEmpty()){
                    Toast.makeText(getApplicationContext(),"Enter City Name",Toast.LENGTH_LONG).show();
                }else{
                    //Log.d("Data",Data);
                    String Url=baseURL+city;
                    MyApplication process = new MyApplication();
                    try {
                        Data=process.execute(Url).get();
                        Log.d("Data",Data.toString());
                        //  textView.setText(Data.toString());
                        cityTxt.setText(Data.get("CityName").toString());
                        idText.setText(Data.get("ID").toString());
                        maxText.setText(Data.get("MaxTemp").toString());
                        minText.setText(Data.get("MinTemp").toString());
                        ndwText.setText(Data.get("NextDayWeather").toString());
                        wcText.setText(Data.get("WeatherCondition").toString());
                        wdText.setText(Data.get("WeatherDate").toString());
                        windDText.setText(Data.get("WindDirection").toString());
                        windSText.setText(Data.get("WindSpeed").toString());
                    } catch (ExecutionException e) {
                        e.printStackTrace();
                    } catch (InterruptedException e) {
                        e.printStackTrace();
                    }
                }
            }
        });
    }

    private void showChangeLanguageDialog() {
        final String [] listItems = {"English", "French"};
        AlertDialog.Builder mBuilder = new AlertDialog.Builder(MainActivity.this);
        mBuilder.setTitle("Choose Language");
        mBuilder.setSingleChoiceItems(listItems, -1, new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int i) {
                if(i == 0){
                    setLocale("en");
                    recreate();
                }
                else if(i == 1){
                    setLocale("fr");
                    recreate();
                }

                //dismiss the dialog language when selected
                dialog.dismiss();
            }
        });
        AlertDialog mDialog = mBuilder.create();
        mDialog.show();
    }

    private void setLocale(String lang) {
        Locale locale = new Locale(lang);
        Locale.setDefault(locale);
        Configuration config = new Configuration();
        config.locale = locale;
        getBaseContext().getResources().updateConfiguration(config, getBaseContext().getResources().getDisplayMetrics());
        //save data to shared preferences
        SharedPreferences.Editor editor = getSharedPreferences("Settings", MODE_PRIVATE).edit();
        editor.putString("My_Lang", lang);
        editor.apply();
    }

    public void loadLocale(){
        SharedPreferences prefs = getSharedPreferences("Settings", Activity.MODE_PRIVATE);
        String language = prefs.getString("My_Lang", "");
        setLocale(language);
    }
}
