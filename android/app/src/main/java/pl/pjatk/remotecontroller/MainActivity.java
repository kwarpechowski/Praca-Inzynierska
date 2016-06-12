package pl.pjatk.remotecontroller;

import android.annotation.TargetApi;
import android.content.Context;
import android.content.SharedPreferences;
import android.os.Build;
import android.preference.PreferenceManager;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.LinearLayout;
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

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main_layout);
        ButterKnife.bind(this);

        SendToServer.start(getBaseContext());

        click1();
    }


    //@OnClick(R.id.btn1)
    protected void click1() {
        System.out.println("click1");
        CustomButton.setLayout(R.drawable.light);
    }

   // @OnClick(R.id.btn2)
    protected void click2() {
        System.out.println("click2");
        CustomButton.setLayout(R.drawable.dark);
    }

}
