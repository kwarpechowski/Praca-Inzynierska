package pl.pjatk.remotecontroller;

import android.os.AsyncTask;
import android.util.Log;

import java.io.DataOutputStream;
import java.io.IOException;
import java.net.Socket;

/**
 * Created by kamilw on 05.06.2016.
 */
public class Runner extends AsyncTask<String, Void, Boolean> {
    private static DataOutputStream dataOutputStream = null;
    private static String host;
    private static int port;
    private static Socket socket;


    public static void close () throws IOException{
        Log.d("siec", "close");
        if(dataOutputStream != null) {
            dataOutputStream.close();
            socket.close();
            dataOutputStream = null;
        }
    }

    public static void saveData (String h, int p) throws IOException{
        host = h;port = p;

    }

    @Override
    protected Boolean doInBackground(String... keys) {
        try {

            if(dataOutputStream == null ) {
                socket = new Socket(Runner.host, Runner.port);
                dataOutputStream = new DataOutputStream(socket.getOutputStream());
            }

            for(String key: keys) {
                Log.i("siec", "pisze "+key);
                dataOutputStream.writeBytes(key);
            }


            return true;
        } catch (IOException e) {
            e.printStackTrace();
            return false;
        }
    }
}