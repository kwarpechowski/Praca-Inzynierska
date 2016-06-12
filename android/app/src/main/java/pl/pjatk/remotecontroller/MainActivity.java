package pl.pjatk.remotecontroller;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;

import butterknife.ButterKnife;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.main_layout);
        ButterKnife.bind(this);

        ServerCommunication.start(this);
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
