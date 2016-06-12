package pl.pjatk.remotecontroller;

import android.support.v7.app.AppCompatActivity;
import android.util.Log;

import com.github.nkzawa.emitter.Emitter;
import com.github.nkzawa.socketio.client.IO;
import com.github.nkzawa.socketio.client.Socket;

import org.json.JSONException;
import org.json.JSONObject;

import java.net.URISyntaxException;


public  class ServerCommunication {
    private static Socket mSocket = null;
    private static AppCompatActivity activity = null;

    public static void start(AppCompatActivity mainActivity) {
        activity = mainActivity;
        ServerCommunication.start();
    }

    private static void start() {
        if(mSocket == null) {
            Log.i("socket", "createServier");
            try {
                mSocket = IO.socket("http://192.168.0.12:5555");
                ServerCommunication.listenDisableButton();
                ServerCommunication.listenEnableButton();
                mSocket.connect();
                mSocket.emit("register_controller");
            } catch (URISyntaxException e) {
            }
        }
    }


    public static void click_button(String buttonName) {
        ServerCommunication.start();
        mSocket.emit("click", buttonName);
    }

    public static void listenDisableButton() {
        mSocket.on("disable_button", new Emitter.Listener() {
            @Override
            public void call(Object... args) {
                try {
                    JSONObject mainObject = new JSONObject(args[0].toString());
                    final String name = mainObject.getString("name");
                    activity.runOnUiThread(new Runnable() {
                       public void run() {
                           CustomButton.disableButton(name);
                       }
                   });
                } catch (JSONException e) {
                    e.printStackTrace();
                }
            }
        });
    }

    private static void listenEnableButton() {
        mSocket.on("enable_button", new Emitter.Listener() {
            @Override
            public void call(Object... args) {
                try {
                    JSONObject mainObject = new JSONObject(args[0].toString());
                    final String name = mainObject.getString("name");
                    activity.runOnUiThread(new Runnable() {
                        public void run() {
                            CustomButton.enableButton(name);
                        }
                    });
                } catch (JSONException e) {
                    e.printStackTrace();
                }
            }
        });
    }
}
