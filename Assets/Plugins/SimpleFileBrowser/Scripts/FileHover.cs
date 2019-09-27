using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace SimpleFileBrowser
{
    public class FileHover : MonoBehaviour
    {
        // Start is called before the first frame update
        FileBrowser fileBrowser = new FileBrowser();
        private Main main;
        bool isHovered = false;

        void Start()
        {
            main = GameObject.Find("Manager").GetComponent<Main>(); 
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void OnTriggerEnter(Collider col) {
            if (!isHovered && col.transform.parent.name.Equals("index")) {
                Image background = this.gameObject.transform.parent.GetComponent<Image>();
                background.color = fileBrowser.hoveredFileColor;
                isHovered = true;
            }
        }

        public void OnTriggerStay(Collider col) {
            if (main.isTouched) {
                main.isTouched = false;
                isHovered = false;
                FileBrowserQuickLink fQuickLink = GameObject.Find("SimpleFileBrowserCanvas").GetComponent<FileBrowserQuickLink>();
                FileBrowserQuickLink link = this.gameObject.transform.parent.GetComponent<FileBrowserQuickLink>();

                print(link);
                fQuickLink.OnHandClick(link);
                // print("Hand : " + link);
                //fileBrowser.OnQuickLinkSelected(link);
            }
        }

        public void OnTriggerExit(Collider col) {
            if (isHovered) {
                Image background = this.gameObject.transform.parent.GetComponent<Image>();
                background.color = fileBrowser.normalFileColor;
                isHovered = false;
            }
        }
    }
}