package pl.pjatk.remotecontroller;

import android.content.Context;
import android.content.SharedPreferences;
import android.preference.PreferenceManager;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Iterator;
import java.util.Map;

import butterknife.ButterKnife;
import butterknife.OnClick;
import butterknife.Bind;

public class MainActivity extends AppCompatActivity {

    @Bind(R.id.button1) Button btn1;
    @Bind(R.id.button2) Button btn2;
    @Bind(R.id.button3) Button btn3;
    @Bind(R.id.button4) Button btn4;
    @Bind(R.id.button5) Button btn5;
    @Bind(R.id.button6) Button btn6;
    @Bind(R.id.button7) Button btn7;
    @Bind(R.id.button8) Button btn8;
    @Bind(R.id.button9) Button btn9;
    @Bind(R.id.button10) Button btn10;

    private HashMap<Integer,Button> buttons = new HashMap<Integer,Button>();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        ButterKnife.bind(this);
        startConnection(getBaseContext());

        this.bindButtons();
    }

    private void bindButtons() {
        buttons.put(1, btn1);
        buttons.put(2, btn2);
        buttons.put(3, btn3);
        buttons.put(4, btn4);
        buttons.put(5, btn5);
        buttons.put(6, btn6);
        buttons.put(7, btn7);
        buttons.put(8, btn8);
        buttons.put(9, btn9);
        buttons.put(10, btn10);

        for(Map.Entry<Integer, Button> e : buttons.entrySet()) {
            final Integer number = e.getKey();
            e.getValue().setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    sendToServer(getString(R.string.btnCommand) + number);
                }
            });
        }

    }

    private void disableButton(Integer buttonId) {
        buttons.get(buttonId).setEnabled(false);
    }

    private void enableButton(Integer buttonId) {
        buttons.get(buttonId).setEnabled(true);
    }

    private void setText(Integer buttonId, String text) {
        buttons.get(buttonId).setText(text);
    }

    private void startConnection(Context context) {
        SharedPreferences SP = PreferenceManager.getDefaultSharedPreferences(context);
        String host = SP.getString(getString(R.string.host), "xxx");
        int port = Integer.parseInt(SP.getString(getString(R.string.port), "666"));

        try {
            Runner.saveData(host, port);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private void sendToServer(String key) {
        try {
            new Runner().execute(key);
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

}
